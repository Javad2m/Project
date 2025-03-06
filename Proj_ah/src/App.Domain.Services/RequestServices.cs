using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services;

public class RequestServices : IRequestServices
{
    private readonly IRequestRepository _requestRepository;

    public RequestServices(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }

    public async Task<bool> AcceptExpert(int id, int expertId, CancellationToken cancellationToken)
    => await _requestRepository.AcceptExpert(id, expertId, cancellationToken);    

    public async Task<bool> CancellRequest(int requestId, CancellationToken cancellationToken)
    => await _requestRepository.CancellRequest(requestId, cancellationToken);   

    public async Task<bool> ChangeRequestStatus(StatusRequestDto status, CancellationToken cancellationToken)
     => await _requestRepository.ChangeRequestStatus(status, cancellationToken);

    public async Task<bool> CreateRequest(RequestDTO model, CancellationToken cancellationToken)
    => await _requestRepository.CreateRequest(model, cancellationToken);

    public async Task<bool> DeleteRequest(int id, CancellationToken cancellationToken)
    => await _requestRepository.DeleteRequest(id, cancellationToken);

    public async Task<bool> DoneRequest(int requestId, CancellationToken cancellationToken)
    => await _requestRepository.DoneRequest(requestId, cancellationToken);

    public async Task<List<RequestDTO>> GetAllRequests(CancellationToken cancellationToken)
    => await _requestRepository.GetAllRequests(cancellationToken);

    public async Task<List<RequestDTO?>> GetRequestByCI(int customerId, CancellationToken cancellationToken)
    => await _requestRepository.GetRequestByCI(customerId, cancellationToken);

    public async Task<RequestDTO> GetRequestById(int id, CancellationToken cancellationToken)
    => await _requestRepository.GetRequestById(id, cancellationToken);

    public async Task<bool> UpdateRequest(RequestDTO model, CancellationToken cancellationToken)
     => await _requestRepository.UpdateRequest(model, cancellationToken);
}
