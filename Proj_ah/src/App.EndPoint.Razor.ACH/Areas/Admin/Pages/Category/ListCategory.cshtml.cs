

using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace App.EndPoint.Razor.ACH.Admin.Pages.Category
{
    [Authorize(Roles = "Admin")]
    public class ListCategoryModel : PageModel
    {
        private readonly ICategoryAppServices _categoryAppService;



        public ListCategoryModel(ICategoryAppServices categoryAppService)
        {

            _categoryAppService = categoryAppService;

        }

        [BindProperty]
        public List<Domain.Core.Entities.Category> Categories { get; set; }

        [BindProperty]
        public CategoryDTO NewCategory { get; set; } = new();

        [BindProperty]
        //public SoftDeleteDto Delete { get; set; }
        public int Delete { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Categories = await _categoryAppService.GetAllCategories(cancellationToken);
        }

        public async Task<IActionResult> OnPostCreateCategory(IFormFile categoryImage, CancellationToken cancellationToken)
        {
            try
            {
                await _categoryAppService.CreateCategory(NewCategory, cancellationToken);
                TempData["Success"] = "دسته‌بندی با موفقیت ایجاد شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("ListCategory");
        }

        public async Task<IActionResult> OnPostUpCategory(CancellationToken cancellationToken)
        {
            try
            {
                await _categoryAppService.UpdateCategory(NewCategory, cancellationToken);
                TempData["Success"] = "دسته‌بندی با موفقیت به‌روزرسانی شد.";

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";

            }
            return RedirectToPage("ListCategory");
        }

        public async Task<IActionResult> OnPostDeleteCategory(CancellationToken cancellationToken)
        {
            try
            {
                await _categoryAppService.DeleteCategoryById(Delete, cancellationToken);
                TempData["Success"] = "دسته‌بندی با موفقیت حذف شد.";

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";

            }
            return RedirectToPage("ListCategory");
        }
    }
}
