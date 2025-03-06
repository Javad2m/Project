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

    Task<bool> ChangeRequestStatus(StatusRequestDto status, CancellationToken cancellationToken);

    Task<List<RequestDTO?>> GetRequestByCI(int customerId, CancellationToken cancellationToken);

    Task<bool> AcceptExpert(int id, int expertId, CancellationToken cancellationToken);
    Task<bool> DoneRequest(int requestId, CancellationToken cancellationToken);
    Task<bool> CancellRequest(int requestId, CancellationToken cancellationToken);

    Task<RequestDTO> GetRequestById(int id, CancellationToken cancellationToken);

    Task<bool> DeleteRequest(int id, CancellationToken cancellationToken);


}
