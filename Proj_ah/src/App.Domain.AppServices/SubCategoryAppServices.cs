using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices;

public class SubCategoryAppServices : ISubCategoryAppServices
{
    private readonly ISubCategoryServices _subCategoryServices;

    public SubCategoryAppServices(ISubCategoryServices subCategoryServices)
    {
        _subCategoryServices = subCategoryServices;
    }
    public async Task<bool> CreateSub(SubCategoryDTO model, CancellationToken cancellationToken)
   => await _subCategoryServices.CreateSub(model, cancellationToken);

    public async Task DeleteSub(SubCategoryDTO model, CancellationToken cancellationToken)
    => await _subCategoryServices.DeleteSub(model, cancellationToken);

    public async Task<List<SubCategoryDTO>> GetAllSub(CancellationToken cancellationToken)
    => await _subCategoryServices.GetAllSub(cancellationToken);

    public async Task UpdateSub(SubCategoryDTO model, CancellationToken cancellationToken)
     => await _subCategoryServices.UpdateSub(model, cancellationToken);
}
