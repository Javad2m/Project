
using App.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace App.EndPoint.Razor.ACH.Admin.Pages.Users
{
    public class DeleteUserModel : PageModel
    {
        private readonly IAccountAppServices _accountAppServices;
        private readonly IAdminAppServices _adminAppService;
        private readonly ICustomerAppServices _customerAppService;
        private readonly IExpertAppServices _expertAppService;
        private readonly ILogger<DeleteUserModel> _logger;

        public DeleteUserModel(IAccountAppServices accountAppServices,
            IAdminAppServices adminAppService,
            ICustomerAppServices customerAppService,
            IExpertAppServices expertAppService,
            ILogger<DeleteUserModel> logger)
        {
            _accountAppServices = accountAppServices;
            _adminAppService = adminAppService;
            _customerAppService = customerAppService;
            _expertAppService = expertAppService;
            _logger = logger;
        }

        [BindProperty]
        public int delete { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, string userType, CancellationToken cancellationToken)
        {
            delete =  id ;

            if (string.IsNullOrEmpty(userType))
            {
                TempData["ErrorMessage"] = "نوع کاربر مشخص نشده است";
                return BadRequest("نوع کاربر مشخص نشده است");
            }

            ViewData["UserType"] = userType;
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id, string userType, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(userType))
            {
                TempData["ErrorMessage"] = "نوع کاربر مشخص نشده است";
                _logger.LogError("نوع کاربر مشخص نشده است. در زمان: {Time}", DateTime.UtcNow.ToLongTimeString());
                return BadRequest("نوع کاربر مشخص نشده است");
            }

            try
            {
                if (userType == "Admin")
                {
                    var admin = await _adminAppService.DeleteAdminById(id, cancellationToken);
                    if (admin == null)
                    {
                        TempData["ErrorMessage"] = "ادمین یافت نشد.";
                        _logger.LogError("ادمین یافت نشد. AdminId: {AdminId} در زمان: {Time}");
                        return NotFound();
                    }
                }
                else if (userType == "Customer")
                {
                    var customer = await _customerAppService.DeleteCustomerById(id, cancellationToken);
                    if (customer == null)
                    {
                        TempData["ErrorMessage"] = "مشتری یافت نشد.";
                        _logger.LogError("مشتری یافت نشد. CustomerId: {CustomerId} در زمان: {Time}");
                        return NotFound();
                    }
                }
                else if (userType == "Expert")
                {
                    var expert = await _expertAppService.DeleteExpertById(id, cancellationToken);
                    if (expert == null)
                    {
                        TempData["ErrorMessage"] = "کارشناس یافت نشد.";
                        _logger.LogError("کارشناس یافت نشد. ExpertId: {ExpertId} در زمان: {Time}");
                        return NotFound();
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "نوع کاربر نامعتبر است.";
                    _logger.LogError("نوع کاربر نامعتبر است. در زمان: {Time}", DateTime.UtcNow.ToLongTimeString());
                    return BadRequest("نوع کاربر نامعتبر است");
                }

                TempData["Success"] = "کاربر با موفقیت حذف شد.";
                _logger.LogInformation("کاربر با موفقیت حذف شد. UserId: {UserId} در زمان: {Time}");
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در حذف کاربر. UserId: {UserId} در زمان: {Time}");
                return RedirectToPage("Index");
            }
        }
    }
}
