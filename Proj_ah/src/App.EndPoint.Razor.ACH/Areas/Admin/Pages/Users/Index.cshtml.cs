
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.EndPoint.Razor.ACH.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAccountAppServices _accountAppServices;
        private readonly IAdminAppServices _adminAppServices;
        private readonly ICustomerAppServices _customerAppServices;
        private readonly IExpertAppServices _expertAppServices;

        public IndexModel(IAccountAppServices accountAppServices,
            IAdminAppServices adminAppService,
            ICustomerAppServices customerAppService,
            IExpertAppServices expertAppService)
        {
            _accountAppServices = accountAppServices;
            _adminAppServices = adminAppService;
            _customerAppServices = customerAppService;
            _expertAppServices = expertAppService;
        }

        [BindProperty]
        public List<Domain.Core.Entities.Expert> Expert { get; set; }

        [BindProperty]
        public List<Domain.Core.Entities.Customer> Customer { get; set; }

        [BindProperty]
        public List<App.Domain.Core.Entities.Admin> Admin { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Expert = await _expertAppServices.GetAllExperts(cancellationToken);
            Customer = await _customerAppServices.GetAllCustomers(cancellationToken);
            Admin = await _adminAppServices.GetAllAdmins(cancellationToken);
        }

        //public async Task<IActionResult> OnPostChangeExpertStatusAsync(int id, bool isActive, CancellationToken cancellationToken)
        //{
        //    if (id <= 0)
        //    {
        //        TempData["ErrorMessage"] = "شناسه نامعتبر است.";
        //        return RedirectToPage();
        //    }

        //    var activeDto = new SoftActiveDto
        //    {
        //        Id = id,
        //        IsActive = isActive
        //    };

        //    try
        //    {
        //        var expert = await _expertAppServices.IActiveExpert(activeDto, cancellationToken);
        //        if (!expert)
        //        {
        //            TempData["ErrorMessage"] = "کارشناس یافت نشد.";
        //            return RedirectToPage();
        //        }

        //        TempData["Success"] = "وضعیت کارشناس با موفقیت تغییر یافت.";
        //        return RedirectToPage("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = "خطا در انجام عملیات";
        //        return RedirectToPage();
        //    }
        //}
    }
}
