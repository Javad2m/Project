
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace App.EndPoint.Razor.ACH.Account.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountAppServices _accountAppServices;
       

        public LoginModel(IAccountAppServices accountAppServices)
        {
            _accountAppServices = accountAppServices;
          
        }

        [BindProperty]
        public ApplicationUserLoginDTO AccountLogin { get; set; }

        public void OnGet()
        {
          
        }

        public async Task<IActionResult> OnPost(ApplicationUserLoginDTO accountLogin, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return Page();
            var succeededLogin = await _accountAppServices.Login(accountLogin.Email, accountLogin.Password, cancellationToken);
            if (succeededLogin)
            {

                if (User.IsInRole("Admin"))
                {
                    TempData["Success"] = "ادمین با موفقیت وارد شد";
                    return LocalRedirect("/Admin/Index");
                }

                if (User.IsInRole("Expert"))
                {
                    TempData["Success"] = ";کارشناس با موفقیت وارد شد";
                    return LocalRedirect("/Expert/Index");
                }

                if (User.IsInRole("Customer"))
                {
                    TempData["Success"] = "مشتری با موفقیت وارد شد";
                    return LocalRedirect("/Customer/Index");

                }
                else
                {
                    TempData["Error"] = "نام کاربری یا رمز عبور نادرست است";
                    return RedirectToPage("/User/Login");
                }
            }
            return Page();
        }
    }
}
