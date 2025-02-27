using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Repositories;

public class SuggestionRepository : ISuggestionRepository
{
    private readonly AppDbContext _context;
    public SuggestionRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateSuggestion(SuggestionDTO model, CancellationToken cancellationToken)
    {
        var newSuggestion = new Suggestion()
        {
            RequestId = model.RequestId,
            Request = model.Request,
            ExpertId = model.ExpertId,
            Expert = model.Expert,
            SuggestedDate = DateTime.Now,
            SuggestedDo = model.SuggestedDo,
            Amount = model.Amount,
            Status = Domain.Core.Enum.SuggestionStatusEnum.AwaitingReview,
        };
        try
        {
            await _context.Suggestions.AddAsync(newSuggestion);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task DeleteSuggestionById(int id, CancellationToken cancellationToken)
    {
        var sug = await _context.Suggestions
           .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

        sug.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<SuggestionDTO>> GetAllSuggestion(CancellationToken cancellationToken)
    {
        var result = await _context.Suggestions
            .Select(model => new SuggestionDTO
            {
                Id = model.Id,
                Descripsion = model.Descripsion,
                RequestId = model.RequestId,
                Request = model.Request,
                Expert = model.Expert,
                IsWinner = model.IsWinner,
                Amount = model.Amount,
                ExpertName = model.Expert.FirstName + " " + model.Expert.LastName,
                Status = model.Status,
                SuggestedDo = model.SuggestedDo,
                
            }).ToListAsync(cancellationToken);

        return result;
    }

    public async Task<bool> UpdateSuggestion(SuggestionDTO model, CancellationToken cancellationToken)
    {
        var sug = await _context.Suggestions
            .AsNoTracking().FirstOrDefaultAsync(b => b.Id == model.Id, cancellationToken);

        try
        {
            sug.RequestId = model.RequestId;
            sug.ExpertId = model.ExpertId;
            sug.Request = model.Request;
            sug.Expert = model.Expert;
            sug.Amount = model.Amount;         
            sug.IsWinner = model.IsWinner;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
           return false;
        }
    }


    public async Task<bool> ChangeSuggestionStatus(SuggestionStatusDto status, CancellationToken cancellationToken)
    {
        var bid = await _context.Suggestions.FirstOrDefaultAsync(x => x.Id == status.Id, cancellationToken);
        if (bid is null)
        {
            return false;
        }
        bid.Status = status.Status;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
