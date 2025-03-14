using App.Domain.Core.Contracts;
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

public class CategoryServices : ICategoryServices
{

    private readonly ICategoryRepository _categoryRepository;

    public CategoryServices(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<bool> CreateCategory(CategoryDTO model, CancellationToken cancellationToken)
     => await _categoryRepository.CreateCategory(model, cancellationToken);

    public async Task DeleteCategoryById(int id, CancellationToken cancellationToken)
    => await _categoryRepository.DeleteCategoryById(id, cancellationToken);

    public async Task<List<Category>> GetAllCategories(CancellationToken cancellationToken)
    => await _categoryRepository.GetAllCategories(cancellationToken);
    

    public async Task<CategoryDTO> GetCategoryById(int categoryId, CancellationToken cancellationToken)
    => await _categoryRepository.GetCategoryById(categoryId, cancellationToken);

    public async Task<bool> UpdateCategory(CategoryDTO model, CancellationToken cancellationToken)
    => await _categoryRepository.UpdateCategory(model, cancellationToken);
}
