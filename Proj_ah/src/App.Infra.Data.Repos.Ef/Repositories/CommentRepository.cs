using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<CommentRepository> _logger;
    public CommentRepository(AppDbContext context, ILogger<CommentRepository> logger)
    {
        _context = context;
        _logger = logger;
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
            _logger.LogInformation("Comment Create Succesfully");

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Comment Create Field");
            return false;
        }
    }

    public async Task DeleteCommentById(int id, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        comment.IsDeleted = true;
        _logger.LogInformation("Comment Delete Succesfully");

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<CommentDTO>> GetAllComments(CancellationToken cancellationToken)
    {
        var result = await _context.Comments
             .Where(d => d.IsDeleted == false)
            .Select(model => new CommentDTO()
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                CommentText = model.CommentText,
                Customer = model.Customer,
                Expert = model.Expert,
                Score = model.Score,
                IsAccept = model.IsAccept,
                CreatAt = model.CreatAt,


            }).ToListAsync(cancellationToken);

        _logger.LogInformation("Comment GetAll Succesfully");
        return result;
        
    }

    public async Task UpdateComment(CommentDTO model, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == model.Id, cancellationToken);

                
            comment.CommentText = model.CommentText;
            comment.Score = model.Score;
        _logger.LogInformation("Comment Update Succesfully");

        await _context.SaveChangesAsync(cancellationToken);
        
        
    }

   public async Task<bool> AcceptComment(CommentAcceptDto commentAcceptDto, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == commentAcceptDto.Id, cancellationToken);
        if (comment is null)
        {
            return false;
        }
        comment.IsAccept = commentAcceptDto.IsAccept;
        await _context.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Comment Accepted Succesfully");

        return true;
    }
}
