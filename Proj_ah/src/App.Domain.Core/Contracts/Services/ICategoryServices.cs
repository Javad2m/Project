using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Services;

public interface ICategoryServices
{
    Task<bool> CreateCategory(CategoryDTO model, CancellationToken cancellationToken);
    Task DeleteCategoryById(int id, CancellationToken cancellationToken);
    Task<List<CategoryDTO>> GetAllCategories(CancellationToken cancellationToken);
    Task<bool> UpdateCategory(CategoryDTO model, CancellationToken cancellationToken);

    Task<CategoryDTO> GetCategoryById(int categoryId, CancellationToken cancellationToken);
}
