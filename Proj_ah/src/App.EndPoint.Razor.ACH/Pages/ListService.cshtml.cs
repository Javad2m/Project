using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoint.Razor.ACH.Pages
{
    public class ListServiceModel : PageModel
    {

        private readonly IServiceSubCategoryAppServices _serviceSubCategoryAppServices;

        public ListServiceModel(IServiceSubCategoryAppServices serviceSubCategoryAppServices)
        {
            _serviceSubCategoryAppServices = serviceSubCategoryAppServices;
        }



        [BindProperty]
        public List<ServiceSubCategoryDTO> Service { get; set; }


        public async Task OnGet(int subCategory, CancellationToken cancellationToken)
        {
            Service = await _serviceSubCategoryAppServices.GetAllBySubId(subCategory, cancellationToken);
        }
    }
}
