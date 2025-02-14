using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repositories;

public interface IRequestRepository
{
    Task<bool> CreateRequest(RequestDTO model, CancellationToken cancellationToken);
    Task<List<RequestDTO>> GetAllRequests(CancellationToken cancellationToken);
    Task<bool> UpdateRequest(RequestDTO model, CancellationToken cancellationToken);

    Task<bool> ChangeRequestStatus(RequestDTO status, CancellationToken cancellationToken);
}
