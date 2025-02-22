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

public class CategoryAppServices : ICategoryAppServices
{
    private readonly ICategoryServices _categoryServices;

    public CategoryAppServices(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;

    }

    public async Task<bool> CreateCategory(CategoryDTO model, CancellationToken cancellationToken)
    => await _categoryServices.CreateCategory(model, cancellationToken);

    public async Task DeleteCategoryById(int id, CancellationToken cancellationToken)
    => await _categoryServices.DeleteCategoryById(id, cancellationToken);

    public async Task<List<Category>> GetAllCategories(CancellationToken cancellationToken)
    => await _categoryServices.GetAllCategories(cancellationToken);

    public async Task<CategoryDTO> GetCategoryById(int categoryId, CancellationToken cancellationToken)
    => await _categoryServices.GetCategoryById(categoryId, cancellationToken);

    public async Task<bool> UpdateCategory(CategoryDTO model, CancellationToken cancellationToken)
    => await _categoryServices.UpdateCategory(model, cancellationToken);
}
