﻿using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices;

public interface ICommentAppServices
{
    Task<bool> CreateComment(CommentDTO model, CancellationToken cancellationToken);
    Task DeleteCommentById(int id, CancellationToken cancellationToken);
    Task<List<CommentDTO>> GetAllComments(CancellationToken cancellationToken);
    Task UpdateComment(CommentDTO model, CancellationToken cancellationToken);
    Task<bool> AcceptComment(CommentAcceptDto commentAcceptDto, CancellationToken cancellationToken);
}
