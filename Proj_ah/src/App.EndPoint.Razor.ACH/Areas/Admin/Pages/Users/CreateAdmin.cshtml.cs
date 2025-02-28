
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace App.EndPoint.Razor.ACH.Admin.Pages.Users
{
    public class CreateAdminModel : PageModel
    {
        private readonly IAccountAppServices _accountAppServices;
        private readonly ILogger<CreateAdminModel> _logger;

        public CreateAdminModel(IAccountAppServices accountAppServices, ILogger<CreateAdminModel> logger)
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
                User.Role = "Admin";
                await _accountAppServices.Register(User, cancellationToken);
                TempData["Success"] = "ادمین با موفقیت ایجاد شد.";
                _logger.LogInformation("Create Admin Succes");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "Create Admin Field");
            }
            return RedirectToPage("Index");
        }
    }
}