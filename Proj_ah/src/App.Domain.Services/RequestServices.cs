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
    public async Task<bool> ChangeRequestStatus(RequestDTO status, CancellationToken cancellationToken)
     => await _requestRepository.ChangeRequestStatus(status, cancellationToken);

    public async Task<bool> CreateRequest(RequestDTO model, CancellationToken cancellationToken)
    => await _requestRepository.CreateRequest(model, cancellationToken);

    public async Task<List<RequestDTO>> GetAllRequests(CancellationToken cancellationToken)
    => await _requestRepository.GetAllRequests(cancellationToken);

    public async Task<bool> UpdateRequest(RequestDTO model, CancellationToken cancellationToken)
     => await _requestRepository.UpdateRequest(model, cancellationToken);
}
