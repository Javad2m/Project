using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoint.Razor.ACH.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICategoryAppServices _categoryAppServices;
        private readonly ISubCategoryAppServices _subCategoryAppServices;
        private readonly IServiceSubCategoryAppServices _serviceSubCategoryAppServices;

        public IndexModel(ILogger<IndexModel> logger, ICategoryAppServices categoryAppServices, ISubCategoryAppServices subCategoryAppServices, IServiceSubCategoryAppServices serviceSubCategoryAppServices)
        {
            _logger = logger;
            _categoryAppServices = categoryAppServices;
            _subCategoryAppServices = subCategoryAppServices;
            _serviceSubCategoryAppServices = serviceSubCategoryAppServices;
        }


        [BindProperty]
        public List<Category> Categories { get; set; }

        [BindProperty]
        public List<ServiceSubCategoryDTO> HomeServices { get; set; }

        [BindProperty]
        public List<SubCategoryDTO?> SubCategories { get; set; }






        public async Task OnGet(CancellationToken cancellationToken)
        {
            Categories = await _categoryAppServices.GetAllCategories(cancellationToken);
            SubCategories = await _subCategoryAppServices.GetAllSub(cancellationToken);
            HomeServices = await _serviceSubCategoryAppServices.GetAllServices(cancellationToken);
        }
    }
}
