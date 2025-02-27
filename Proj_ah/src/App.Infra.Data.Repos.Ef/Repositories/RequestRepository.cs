using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Repositories;

public class RequestRepository : IRequestRepository
{
    private readonly AppDbContext _context;
    public RequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateRequest(RequestDTO model, CancellationToken cancellationToken)
    {
        var newRequest = new Request()
        {
            Customer = model.Customer,
            CreatedAt = DateTime.Now,
            DoneTime = model.DoneTime,
            Status = Domain.Core.Enum.RequestStatusEnum.CheckingAndWaitingExpert,
            Description = model.Description,
            CustomerId = model.CustomerId,
            BasePrice = model.BasePrice,
            

        };
        try
        {
            await _context.Requests.AddAsync(newRequest);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
    public async Task<List<RequestDTO>> GetAllRequests(CancellationToken cancellationToken)
    {
        var result = await _context.Requests
            .Select(model => new RequestDTO
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                Status = model.Status,
                Description = model.Description,
                BasePrice = model.BasePrice

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
        var request = await FindRequest(status.Id, cancellationToken);
        request.Status = status.Status;

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    private async Task<Request> FindRequest(int id, CancellationToken cancellationToken)
    {
        var request = await _context.Requests
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

        if (request != null)
        {
            return request;
        }

        throw new Exception($"Request with id {id} not found");
    }

}
