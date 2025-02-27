
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace App.EndPoint.Razor.ACH.Admin.Pages.Users
{
    public class AdminUpModel : PageModel
    {
        private readonly IAccountAppServices _accountAppServices;
        private readonly IAdminAppServices _adminAppService;

        public AdminUpModel(
            IAccountAppServices accountAppServices,
            IAdminAppServices adminAppService
        )
        {
            _accountAppServices = _accountAppServices;
            _adminAppService = adminAppService;
        }

        [BindProperty]
        public AdminDTO UpAdmin { get; set; }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            UpAdmin = await _adminAppService.GetById(id, cancellationToken);
        }

        public async Task<IActionResult> OnPostUpdate(CancellationToken cancellationToken)
        {
            try
            {
                var admin = await _adminAppService.UpdateAdmin(UpAdmin, cancellationToken);
                if (admin == null)
                {
                    TempData["ErrorMessage"] = "خطا در انجام عملیات";
                    return NotFound();
                }

                TempData["Success"] = "اطلاعات ادمین با موفقیت به‌روزرسانی شد.";
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                return RedirectToPage("Index");
            }
        }
    }
}
