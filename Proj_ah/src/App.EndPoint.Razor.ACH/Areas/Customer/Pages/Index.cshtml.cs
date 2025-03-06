using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading;

namespace App.EndPoint.Razor.ACH.Areas.Customer.Pages
{
    [Authorize(Roles = "Customer")]
    public class IndexModel : PageModel
    {
        private readonly ICustomerAppServices _customerAppServices;

        public IndexModel(ICustomerAppServices customerAppServices)
        {
            _customerAppServices = customerAppServices;
        }


        [BindProperty]
        public CustomerDTO Customer { get; set; }


        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userCustomerId").Value);


            
            Customer = await _customerAppServices.GetById(userId, cancellationToken);
        }
    }
}
