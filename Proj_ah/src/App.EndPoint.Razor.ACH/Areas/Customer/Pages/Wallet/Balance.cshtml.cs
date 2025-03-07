using App.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace App.EndPoint.Razor.ACH.Areas.Customer.Pages.Wallet
{
    [Authorize(Roles = "Customer")]
    public class BalanceModel : PageModel
    {
        private readonly ICustomerAppServices _customerAppServices;

        public BalanceModel(ICustomerAppServices customerAppServices)
        {
            _customerAppServices = customerAppServices;
        }


        [BindProperty]
        [Range(100.01f, float.MaxValue, ErrorMessage = "???? ?????? ?? 100 ????")]

        public float Balance { get; set; }




        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userCustomerId").Value);
            var user = await _customerAppServices.GetById(userId, cancellationToken);

            Balance = user.Wallet;

        }


        public async Task<IActionResult> OnPostBalance(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "?????? ?????? ????? ???";
                return RedirectToPage();
            }

            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userCustomerId").Value);
            await _customerAppServices.UpdateBalance(userId, Balance, cancellationToken);

            TempData["Success"] = "Inventory increase completed successfully.";
            return RedirectToPage();

        }
    }
}
