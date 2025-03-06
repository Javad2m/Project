using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoint.Razor.ACH.Pages
{
    public class SubCategoryModel : PageModel
    {
        private readonly ISubCategoryAppServices _subCategoryAppServices;
        private readonly IServiceSubCategoryAppServices _serviceSubCategoryAppServices;

        public SubCategoryModel(ISubCategoryAppServices subCategoryAppServices, IServiceSubCategoryAppServices serviceSubCategoryAppServices )
        {
            _serviceSubCategoryAppServices = serviceSubCategoryAppServices;
            _subCategoryAppServices = subCategoryAppServices;
        }

        [BindProperty]
        public List<ServiceSubCategoryDTO> HomeServices { get; set; }

        [BindProperty]
        public List<SubCategoryDTO?> SubCategories { get; set; }






        public async Task OnGet(CancellationToken cancellationToken)
        {
            SubCategories = await _subCategoryAppServices.GetAllSub(cancellationToken);
            HomeServices = await _serviceSubCategoryAppServices.GetAllServices(cancellationToken);
        }
    }
}
