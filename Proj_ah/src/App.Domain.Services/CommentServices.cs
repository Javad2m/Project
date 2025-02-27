using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services;

public class CommentServices : ICommentServices
{
    private readonly ICommentRepository _commentRepository;

    public CommentServices(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    public async Task<bool> CreateComment(CommentDTO model, CancellationToken cancellationToken)
     => await _commentRepository.CreateComment(model, cancellationToken);

    public async Task DeleteCommentById(int id, CancellationToken cancellationToken)
    => await _commentRepository.DeleteCommentById(id, cancellationToken);

    public async Task<List<CommentDTO>> GetAllComments(CancellationToken cancellationToken)
    => await _commentRepository.GetAllComments(cancellationToken);

    public async Task UpdateComment(CommentDTO model, CancellationToken cancellationToken)
    => await _commentRepository.UpdateComment(model, cancellationToken);

    public async Task<bool> AcceptComment(CommentAcceptDto commentAcceptDto, CancellationToken cancellationToken)
   => await _commentRepository.AcceptComment(commentAcceptDto, cancellationToken);
}
