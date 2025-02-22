
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoint.Razor.ACH.Admin.Pages.SubCategory
{
    public class ListSubCategoryModel : PageModel
    {
        private readonly ISubCategoryAppServices _subCategoryAppService;
        private readonly ICategoryAppServices _categoryAppService;


        public ListSubCategoryModel(ISubCategoryAppServices subcategoryAppService, ICategoryAppServices categoryAppService, ILogger<IndexModel> logger)
        {
            _subCategoryAppService = subcategoryAppService;
            _categoryAppService = categoryAppService;

        }

        [BindProperty]
        public List<SubCategoryDTO> SubCategories { get; set; }

        [BindProperty]
        public SubCategoryDTO NewSubCategory { get; set; } = new();

        [BindProperty]
        public List<App.Domain.Core.Entities.Category> Categories { get; set; } = new();

        [BindProperty]
        //public SoftDeleteDto Delete { get; set; }
        public int Delete { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            SubCategories = await _subCategoryAppService.GetAllSub(cancellationToken);
            Categories = await _categoryAppService.GetAllCategories(cancellationToken);
        }

        public async Task<IActionResult> OnPostCreateCategory(CancellationToken cancellationToken)
        {
            try
            {
                await _subCategoryAppService.CreateSub(NewSubCategory, cancellationToken);
                TempData["Success"] = "زیرمجموعه با موفقیت ایجاد شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("ListSubCategory");
        }

        public async Task<IActionResult> OnPostUpCategory(CancellationToken cancellationToken)
        {
            try
            {
                await _subCategoryAppService.UpdateSub(NewSubCategory, cancellationToken);
                TempData["Success"] = "زیرمجموعه با موفقیت به‌روزرسانی شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("ListSubCategory");
        }

        public async Task<IActionResult> OnPostDeleteCategory(CancellationToken cancellationToken)
        {
            try
            {
                await _subCategoryAppService.DeleteSub(Delete, cancellationToken);
                TempData["Success"] = "زیرمجموعه با موفقیت حذف شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("ListSubCategory");
        }
    }
}
