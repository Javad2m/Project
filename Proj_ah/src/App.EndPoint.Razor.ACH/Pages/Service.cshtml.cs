using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoint.Razor.ACH.Pages
{
    public class ServiceModel : PageModel
    {

        private readonly IServiceSubCategoryAppServices _serviceSubCategoryAppServices;

        public ServiceModel(IServiceSubCategoryAppServices serviceSubCategoryAppServices)
        {
            _serviceSubCategoryAppServices = serviceSubCategoryAppServices;
        }

        [BindProperty]
        public ServiceSubCategoryDTO Service { get; set; }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            Service = await _serviceSubCategoryAppServices.GetServiceById(id, cancellationToken);
        }
    }
}
