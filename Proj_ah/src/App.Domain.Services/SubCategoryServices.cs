using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services;

public class SubCategoryServices : ISubCategoryServices
{
    private readonly ISubCategoryRepository _subCategoryRepository;

    public SubCategoryServices(ISubCategoryRepository subCategoryRepository)
    {
        _subCategoryRepository = subCategoryRepository;
    }
    public async Task<bool> CreateSub(SubCategoryDTO model, CancellationToken cancellationToken)
    => await _subCategoryRepository.CreateSub(model, cancellationToken);

    public async Task DeleteSub(int id, CancellationToken cancellationToken)
    => await _subCategoryRepository.DeleteSub(id, cancellationToken);

    public async Task<List<SubCategoryDTO>> GetAllSub(CancellationToken cancellationToken)
    => await _subCategoryRepository.GetAllSub(cancellationToken);

    public async Task UpdateSub(SubCategoryDTO model, CancellationToken cancellationToken)
     => await _subCategoryRepository.UpdateSub(model, cancellationToken);
}
