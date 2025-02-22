using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repositories;

public interface ISubCategoryRepository
{
    Task<bool> CreateSub(SubCategoryDTO model, CancellationToken cancellationToken);
    Task<List<SubCategoryDTO>> GetAllSub(CancellationToken cancellationToken);

    Task UpdateSub(SubCategoryDTO model, CancellationToken cancellationToken);

    Task DeleteSub(int id, CancellationToken cancellationToken);
}
