
using App.Domain.AppServices;
using App.Domain.Core.Contracts.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoint.Razor.ACH.Admin.Pages
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAdminAppServices _adminAppService;
        private readonly IExpertAppServices _expertAppService;
        private readonly ICustomerAppServices _customerAppService;
        private readonly ICategoryAppServices _categoryAppService;
        private readonly ISubCategoryAppServices _subCategoryAppService;
        private readonly IServiceSubCategoryAppServices _homeServiceAppService;
        private readonly ICommentAppServices _commentAppService;
        private readonly IRequestAppServices _requestAppService;


        public IndexModel(
                   IAdminAppServices adminAppService,
                   IExpertAppServices expertAppService,
                   ICustomerAppServices customerAppService,
                   ICategoryAppServices categoryAppService,
                   ISubCategoryAppServices subCategoryAppService,
                   IServiceSubCategoryAppServices homeServiceAppService,
                   ICommentAppServices commentAppService,
                   IRequestAppServices requestAppService
            )
                

        {
            _adminAppService = adminAppService;
            _expertAppService = expertAppService;
            _customerAppService = customerAppService;
            _categoryAppService = categoryAppService;
            _subCategoryAppService = subCategoryAppService;
            _homeServiceAppService = homeServiceAppService;
            _commentAppService = commentAppService;
            _requestAppService = requestAppService;
           
        }

[BindProperty]
public int CountAdmin { get; set; }
[BindProperty]
public int CountExperts { get; set; }
[BindProperty]
public int CountCustomers { get; set; }
[BindProperty]
public int CountCategories { get; set; }
[BindProperty]
public int CountSubCategories { get; set; }
[BindProperty]
public int CountHomeServices { get; set; }
[BindProperty]
public int CountComments { get; set; }
[BindProperty]
public int CountRequests { get; set; }

public async Task OnGet(CancellationToken cancellationToken)
{
    //try
    //{
    //    CountAdmin = await _adminAppService.AdminCount(cancellationToken);
    //    CountExperts = await _expertAppService.ExpertCount(cancellationToken);
    //    CountCustomers = await _customerAppService.CoustomerCount(cancellationToken);
    //    CountCategories = await _categoryAppService.CategoryCount(cancellationToken);
    //    CountSubCategories = await _subCategoryAppService.SubCategoryCount(cancellationToken);
    //    CountHomeServices = await _homeServiceAppService.HomeServiceCount(cancellationToken);
    //    CountComments = await _commentAppService.CommentCount(cancellationToken);
    //    CountRequests = await _requestAppService.RequestCount(cancellationToken);

    //    _logger.LogInformation("تعدادها با موفقیت بازیابی شدند زمان  {Time}", DateTime.UtcNow.ToLongTimeString());
    //}
    //catch (Exception ex)
    //{
    //    _logger.LogError(ex, "خطا در بازیابی تعدادها. زمان: {Time}", DateTime.UtcNow.ToLongTimeString());
    //}
}





    }
}

