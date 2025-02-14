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

public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;

    public CommentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateComment(CommentDTO model, CancellationToken cancellationToken)
    {
        var newComment = new Comment()
        {
            CommentText = model.CommentText,
            CreatAt = DateTime.Now,
            CustomerId = model.CustomerId,
            ExpertId = model.ExpertId,
            Score = model.Score,

        };
        try
        {
            await _context.Comments.AddAsync(newComment);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task DeleteCommentById(int id, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        comment.IsDeleted = true;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<CommentDTO>> GetAllComments(CancellationToken cancellationToken)
    {
        var result = await _context.Comments
            .Select(model => new CommentDTO()
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                CommentText = model.CommentText,
                Customer = model.Customer,
                Expert = model.Expert,
                Score = model.Score,


            }).ToListAsync(cancellationToken);

        return result;
    }

    public async Task UpdateComment(CommentDTO model, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == model.Id, cancellationToken);

                
            comment.CommentText = model.CommentText;
            comment.Score = model.Score;

            await _context.SaveChangesAsync(cancellationToken);
        
        
    }
}
