using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using App.Domain.Core.Enum;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Repositories;

public class RequestRepository : IRequestRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<RequestRepository> _logger;

    public RequestRepository(AppDbContext context, ILogger<RequestRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<bool> CreateRequest(RequestDTO model, CancellationToken cancellationToken)
    {

        if (model.BasePrice <= 0)
        {
            _logger.LogError("BasePrice باید بیشتر از صفر باشد.");
            return false;
        }
        var newRequest = new Request()
        {
            CreatedAt = DateTime.Now,
            DoneTime = model.DoneTime,
            Status = Domain.Core.Enum.RequestStatusEnum.CheckingAndWaitingExpert,
            Description = model.Description,
            CustomerId = model.CustomerId,
            BasePrice = model.BasePrice,
            ServiceSubCategoryId = model.ServiceSubCategoryId,


        };
        try
        {
            await _context.Requests.AddAsync(newRequest);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Request Create Succesfully");

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Request not created Maybe it has already been added Or there is another error {exception}", ex.Message);

            return false;
        }

    }
    public async Task<List<RequestDTO>> GetAllRequests(CancellationToken cancellationToken)
    {
        var result = await _context.Requests
             .Where(d => d.IsDeleted == false)
             .Include(d => d.ServiceSubCategory)
            .Select(model => new RequestDTO
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                Status = model.Status,
                Description = model.Description,
                BasePrice = model.BasePrice,
                ServiceSubCategory = model.ServiceSubCategory,


            }).AsNoTracking().ToListAsync(cancellationToken);

        return result;
    }

    public async Task<bool> UpdateRequest(RequestDTO model, CancellationToken cancellationToken)
    {
        var request = await _context.Requests
            .FirstOrDefaultAsync(e => e.Id == model.Id, cancellationToken);

        if (request == null) return false;

        try
        {
            request.Status = model.Status;
            request.Description = model.Description;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> ChangeRequestStatus(StatusRequestDto status, CancellationToken cancellationToken)
    {
        var request = await FindRequestById(status.Id, cancellationToken);
        request.Status = status.Status;

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Request status changed successfully: {RequestId}");

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to change request status: {RequestId}");

            return false;
        }
    }
    private async Task<Request> FindRequestById(int id, CancellationToken cancellationToken)
    {
        var request = await _context.Requests
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

        if (request != null)
        {
            return request;
        }
        _logger.LogWarning("Request not found: {RequestId}", id);

        throw new Exception($"Request with id {id} not found");
    }

    public async Task<List<RequestDTO?>> GetRequestByCI(int customerId, CancellationToken cancellationToken)
    {
        var requests = await _context.Requests.AsNoTracking()
              .Where(r => r.CustomerId == customerId)
               .Where(d => d.IsDeleted == false)
              .Include(r => r.Customer)
              .ThenInclude(c => c.ApplicationUser)
              .Include(r => r.ServiceSubCategory)
              .Include(s => s.Suggestions)
              .Select(r => new RequestDTO
              {
                  Id = r.Id,
                  Description = r.Description,
                  BasePrice = r.BasePrice,
                  Status = r.Status,
                  DoneTime = r.DoneTime,
                  CreatedAt = r.CreatedAt,
                  CustomerId = r.CustomerId,
                  ServiceSubCategoryId = r.ServiceSubCategoryId,

                  Suggestions = r.Suggestions.ToList()


              })
              .ToListAsync(cancellationToken);
        return requests;
    }

    public async Task<bool> AcceptExpert(int id, int expertId, CancellationToken cancellationToken)
    {
        var acceptRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (acceptRequest is null)
        {
            return false;
        }

        //acceptRequest.Suggestions = null;
        acceptRequest.Status = Domain.Core.Enum.RequestStatusEnum.RegisteredByExpert;

        var sug = await _context.Suggestions.FirstOrDefaultAsync(x => x.Id == expertId, cancellationToken);
        if (sug is null)
        {
            return false;
        }
        sug.Status = Domain.Core.Enum.SuggestionStatusEnum.Accept;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }


    public async Task<bool> DoneRequest(int requestId, CancellationToken cancellationToken)
    {
        var acceptRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id == requestId, cancellationToken);
        if (acceptRequest is null)
        {
            return false;
        }
        acceptRequest.Status = Domain.Core.Enum.RequestStatusEnum.Done;
        var sug = await _context.Suggestions.FirstOrDefaultAsync(x => x.RequestId == acceptRequest.Id, cancellationToken);
        if (sug is null)
        {
            return false;
        }
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> CancellRequest(int requestId, CancellationToken cancellationToken)
    {
        var acceptRequest = await _context.Requests.FirstOrDefaultAsync(x => x.Id == requestId, cancellationToken);
        if (acceptRequest is null)
        {
            return false;
        }
        acceptRequest.Status = RequestStatusEnum.CheckingAndWaitingExpert;
        var sug = await _context.Suggestions.FirstOrDefaultAsync(x => x.RequestId == acceptRequest.Id, cancellationToken);
        if (sug is null)
        {
            return false;
        }
        sug.Status = SuggestionStatusEnum.Reject;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<RequestDTO> GetRequestById(int id, CancellationToken cancellationToken)
    {
        var request = await _context.Requests
            .Where(r => r.Id == id)
            .Select(r => new RequestDTO
            {
                Id = r.Id,
                Description = r.Description,
                BasePrice = r.BasePrice,
                Status = r.Status,
                DoneTime = r.DoneTime,
                CreatedAt = r.CreatedAt,
                CustomerId = r.CustomerId,
                ServiceSubCategoryId = r.ServiceSubCategoryId,
                Suggestions = r.Suggestions.ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        return request;
    }

    public async Task<bool> DeleteRequest(int id, CancellationToken cancellationToken)
    {
        var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (request is null)
        {
            return false;
        }
        request.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}

