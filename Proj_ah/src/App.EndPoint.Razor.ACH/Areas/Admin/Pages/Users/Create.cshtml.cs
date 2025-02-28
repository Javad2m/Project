
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.EndPoint.Razor.ACH.Admin.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IAccountAppServices _accountAppServices;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(IAccountAppServices accountAppServices, ILogger<CreateModel> logger)
        {
            _accountAppServices = accountAppServices;
            _logger = logger;
        }

        [BindProperty]
        public AppliccationUserDTO User { get; set; }

       

        public async Task OnGet(CancellationToken cancellationToken)
        {
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            try
            {
                await _accountAppServices.Register(User, cancellationToken);
                TempData["Success"] = "کاربر با موفقیت ایجاد شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("Index");
        }
    }
}
