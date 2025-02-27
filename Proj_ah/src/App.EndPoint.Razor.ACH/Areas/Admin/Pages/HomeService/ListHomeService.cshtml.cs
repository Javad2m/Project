
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;

namespace App.EndPoint.Razor.ACH.Admin.Pages.HomeService
{
    public class ListHomeServiceModel : PageModel
    {
        private readonly IServiceSubCategoryAppServices _serviceSubCategoryAppServices;
        private readonly ISubCategoryAppServices _subCategoryAppService;

        public ListHomeServiceModel(IServiceSubCategoryAppServices serviceSubCategoryAppServices, ISubCategoryAppServices subCategoryAppService)
        {
            _serviceSubCategoryAppServices = serviceSubCategoryAppServices;
            _subCategoryAppService = subCategoryAppService;
        }

        [BindProperty]
        public List<ServiceSubCategoryDTO> HomeServices { get; set; }

        [BindProperty]
        public ServiceSubCategoryDTO NewHomeService { get; set; } = new();

        [BindProperty]
        public List<SubCategoryDTO?> SubCategories { get; set; } = new();

        [BindProperty]
        //public SoftDeleteDto Delete { get; set; }
        public int Delete { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            HomeServices = await _serviceSubCategoryAppServices.GetAllServices(cancellationToken);
            SubCategories = await _subCategoryAppService.GetAllSub(cancellationToken);
        }

        public async Task<IActionResult> OnPostCreateService(CancellationToken cancellationToken)
        {
            try
            {
                await _serviceSubCategoryAppServices.CreateService(NewHomeService, cancellationToken);
                TempData["Success"] = "خدمات با موفقیت ایجاد شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"خطایی رخ داد: {ex.Message}";
            }
            return RedirectToPage("ListHomeService");
        }

        public async Task<IActionResult> OnPostUpService(CancellationToken cancellationToken)
        {
            try
            {
                await _serviceSubCategoryAppServices.UpdateService(NewHomeService, cancellationToken);
                TempData["Success"] = "خدمات با موفقیت به‌روزرسانی شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"خطایی رخ داد: {ex.Message}";
            }
            return RedirectToPage("ListHomeService");
        }

        public async Task<IActionResult> OnPostDeleteService(CancellationToken cancellationToken)
        {
            try
            {
                await _serviceSubCategoryAppServices.DeleteService(Delete, cancellationToken);
                TempData["Success"] = "خدمات با موفقیت حذف شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("ListHomeService");
        }
    }
}
