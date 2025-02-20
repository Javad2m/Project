using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices;

public class RequestAppServices : IRequestAppServices
{
    private readonly IRequestServices _requestServices;

    public RequestAppServices(IRequestServices requestServices)
    {
        _requestServices = requestServices;

    }

    public async Task<bool> ChangeRequestStatus(RequestDTO status, CancellationToken cancellationToken)
    => await _requestServices.ChangeRequestStatus(status, cancellationToken);

    public async Task<bool> CreateRequest(RequestDTO model, CancellationToken cancellationToken)
    => await _requestServices.CreateRequest(model, cancellationToken);

    public async Task<List<RequestDTO>> GetAllRequests(CancellationToken cancellationToken)
    => await _requestServices.GetAllRequests(cancellationToken);

    public async Task<bool> UpdateRequest(RequestDTO model, CancellationToken cancellationToken)
     => await _requestServices.UpdateRequest(model, cancellationToken);
}
