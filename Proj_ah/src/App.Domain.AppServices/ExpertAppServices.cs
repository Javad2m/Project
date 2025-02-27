using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices;

public class ExpertAppServices : IExpertAppServices
{
    private readonly IExpertServices _expertServices;

    public ExpertAppServices(IExpertServices expertServices)
    {
        _expertServices = expertServices;
    }

    public async Task<List<Expert>> GetAllExperts(CancellationToken cancellationToken)
    => await _expertServices.GetAllExperts(cancellationToken);
}
