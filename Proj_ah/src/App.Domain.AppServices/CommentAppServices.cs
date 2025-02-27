using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices;

public class CommentAppServices : ICommentAppServices
{
    private readonly ICommentServices _commentServices;

    public CommentAppServices(ICommentServices commentServices)
    {
        _commentServices = commentServices;

    }

    public async Task<bool> AcceptComment(CommentAcceptDto commentAcceptDto, CancellationToken cancellationToken)
    => await _commentServices.AcceptComment(commentAcceptDto, cancellationToken);

    public async Task<bool> CreateComment(CommentDTO model, CancellationToken cancellationToken)
    => await _commentServices.CreateComment(model, cancellationToken);

    public async Task DeleteCommentById(int id, CancellationToken cancellationToken)
    => await _commentServices.DeleteCommentById(id, cancellationToken);

    public async Task<List<CommentDTO>> GetAllComments(CancellationToken cancellationToken)
    => await _commentServices.GetAllComments(cancellationToken);

    public async Task UpdateComment(CommentDTO model, CancellationToken cancellationToken)
    => await _commentServices.UpdateComment(model, cancellationToken);
}
