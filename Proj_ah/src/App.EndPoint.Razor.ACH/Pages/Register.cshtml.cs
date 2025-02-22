using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.EndPoint.Razor.ACH.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountAppServices _accountAppServices;

        

        public RegisterModel(IAccountAppServices accountAppServices)
        {
            _accountAppServices = accountAppServices;

            
        }

        [BindProperty]
        public AppliccationUserDTO AccountRegister { get; set; }





        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken, string returnUrl = null)
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                var result = await _accountAppServices.Register(AccountRegister, cancellationToken);
                if (result.Count == 0)
                {
                    TempData["Success"] = "ثبت‌نام با موفقیت انجام شد.";

                    return LocalRedirect(returnUrl ?? Url.Content("~/Account/Login"));
                }

                foreach (var error in result)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                TempData["ErrorMessage"] = "خطا در انجام عملیات ثبت‌نام.";

                return Page();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات.";

                return Page();
            }
        }
    }
}
