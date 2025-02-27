using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoint.Razor.ACH.Account.Pages
{
    public class LogoutModel(SignInManager<ApplicationUser> signInManager) : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();
           

            return RedirectToPage("Login");
        }

    }
}
