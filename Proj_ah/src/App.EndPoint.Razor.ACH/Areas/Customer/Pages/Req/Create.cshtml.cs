using App.Domain.AppServices;
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoint.Razor.ACH.Areas.Customer.Pages.Req
{

    [Authorize(Roles = "Customer")]
    public class CreateModel : PageModel
    {

        private readonly IRequestAppServices _requestAppServices;
        private readonly IServiceSubCategoryAppServices _serviceSubCategoryAppServices;

        public CreateModel(IRequestAppServices requestAppServices, IServiceSubCategoryAppServices serviceSubCategoryAppServices )
        {
            _requestAppServices = requestAppServices;
            _serviceSubCategoryAppServices = serviceSubCategoryAppServices;
        }


        [BindProperty]
        public RequestDTO Request { get; set; } = new RequestDTO();


        [BindProperty]
        public List<ServiceSubCategoryDTO> Services { get; set; }


        public async Task OnGet(int? id,CancellationToken cancellationToken)
        {
            Services = await _serviceSubCategoryAppServices.GetAllServices(cancellationToken);
            if (id.HasValue)
            {
                Request.ServiceSubCategoryId = id.Value;
            }

        }

        public async Task<IActionResult> OnPostCreate(CancellationToken cancellationToken)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userCustomerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId").Value);
                    Request.CustomerId = userCustomerId;
                    await _requestAppServices.CreateRequest(Request, cancellationToken);
                    TempData["Success"] = "The request was successfully submitted.";
                    return RedirectToPage("../Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Field";
                    return RedirectToPage("../Index");
                }
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                return RedirectToPage("../Index");
            }
        }
    }
}
