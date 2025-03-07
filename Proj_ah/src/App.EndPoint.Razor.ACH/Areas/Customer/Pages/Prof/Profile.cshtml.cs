using App.Domain.AppServices;
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities.BaseEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoint.Razor.ACH.Areas.Customer.Pages.Prof
{

    [Authorize(Roles = "Customer")]
    public class ProfileModel : PageModel
    {

        private readonly ICustomerAppServices _customerAppServices;

        private readonly ICityAppServices _cityAppServices;

        public ProfileModel(ICustomerAppServices customerAppServices, ICityAppServices cityAppServices)
        {
            _customerAppServices = customerAppServices;
            _cityAppServices = cityAppServices;
        }

        [BindProperty]
        public CustomerDTO Customer { get; set; } = new CustomerDTO();

        [BindProperty]
        public List<City> Cities { get; set; } = new List<City>();



        public async Task OnGet(CancellationToken cancellationToken)
        {
            var customerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId").Value);

            Customer = await _customerAppServices.GetById(customerId, cancellationToken);

            Cities = await _cityAppServices.GetAll(cancellationToken);

        }

        public async Task<IActionResult> OnPostUpdate(CancellationToken cancellationToken)
        {
            
                var userCustomerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId").Value);
                Customer.Id = userCustomerId;
                await _customerAppServices.UpdateCustomer(Customer, cancellationToken);
                TempData["Success"] = "Information updated successfully.";
                return RedirectToPage();
           
        }
    }
}
