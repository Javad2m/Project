using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services;

public class ExpertServices : IExpertServices
{

    private readonly IExpertRepository _expertRepository;

    public ExpertServices(IExpertRepository expertRepository)
    {
        _expertRepository = expertRepository;
    }
    public async Task<bool> CreateExpert(ExpertDTO model, CancellationToken cancellationToken)
    => await _expertRepository.CreateExpert(model, cancellationToken);

    public async Task<bool> DeleteExpertById(int id, CancellationToken cancellationToken)
    => await _expertRepository.DeleteExpertById(id, cancellationToken);

    public async Task<List<Expert>> GetAllExperts(CancellationToken cancellationToken)
     => await _expertRepository.GetAllExperts(cancellationToken);

    public async Task<ExpertDTO>? GetExpertById(int id, CancellationToken cancellationToken)
     => await _expertRepository.GetExpertById(id, cancellationToken);

    public async Task UpdateExpert(ExpertDTO model, CancellationToken cancellationToken)
     => await _expertRepository.UpdateExpert(model, cancellationToken);
}
