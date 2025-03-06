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

    private readonly ICustomerAppServices _customerAppServices;

    public RequestAppServices(IRequestServices requestServices, ICustomerAppServices customerAppServices)
    {
        _requestServices = requestServices;
        _customerAppServices = customerAppServices;
    }

    public async Task<bool> AcceptExpert(int id, int expertId, CancellationToken cancellationToken)
    {

        var cus =await _customerAppServices.GetById(expertId, cancellationToken);
        var req = await GetRequestById(id,cancellationToken);
        if (cus.Wallet < req.BasePrice)
        {
            return false;
        }


        return await _requestServices.AcceptExpert(id, expertId, cancellationToken);

    }

    public async Task<bool> CancellRequest(int requestId, CancellationToken cancellationToken)
    => await _requestServices.CancellRequest(requestId, cancellationToken);

    public async Task<bool> ChangeRequestStatus(StatusRequestDto status, CancellationToken cancellationToken)
    => await _requestServices.ChangeRequestStatus(status, cancellationToken);

    public async Task<bool> CreateRequest(RequestDTO model, CancellationToken cancellationToken)
    => await _requestServices.CreateRequest(model, cancellationToken);

    public async Task<bool> DeleteRequest(int id, CancellationToken cancellationToken)
    => await _requestServices.DeleteRequest(id, cancellationToken); 

    public async Task<bool> DoneRequest(int requestId, CancellationToken cancellationToken)
    => await _requestServices.DoneRequest(requestId, cancellationToken);

    public async Task<List<RequestDTO>> GetAllRequests(CancellationToken cancellationToken)
    => await _requestServices.GetAllRequests(cancellationToken);

    public async Task<List<RequestDTO?>> GetRequestByCI(int customerId, CancellationToken cancellationToken)
    => await _requestServices.GetRequestByCI(customerId, cancellationToken);

    public async Task<RequestDTO> GetRequestById(int id, CancellationToken cancellationToken)
    => await _requestServices.GetRequestById(id, cancellationToken);

    public async Task<bool> UpdateRequest(RequestDTO model, CancellationToken cancellationToken)
     => await _requestServices.UpdateRequest(model, cancellationToken);
}
