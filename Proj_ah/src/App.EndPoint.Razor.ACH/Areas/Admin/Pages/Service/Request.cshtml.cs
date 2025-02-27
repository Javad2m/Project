
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using App.Domain.Core.Enum;

namespace App.EndPoint.Razor.ACH.Admin.Pages.Service
{
    public class RequestModel : PageModel
    {
        private readonly IRequestAppServices _requestAppService;


        public RequestModel(IRequestAppServices requestAppService)
        {
            _requestAppService = requestAppService;

        }

        [BindProperty]
        public List<RequestDTO?> Requests { get; set; }

        [BindProperty]
        //public SoftDeleteDto Delete { get; set; }
        public int Delete { get; set; }

        [BindProperty]
        public StatusRequestDto Status { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Requests = await _requestAppService.GetAllRequests(cancellationToken);
        }

        public async Task<IActionResult> OnPostChangeStatusRequest(CancellationToken cancellationToken)
        {
            try
            {
                await _requestAppService.ChangeRequestStatus(Status, cancellationToken);
                TempData["Success"] = "وضعیت درخواست با موفقیت تغییر یافت.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("Request");
        }

        //public async Task<IActionResult> OnPostDeleteRequest(CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        await _requestAppService.DeleteRequest(Delete, cancellationToken);
        //        TempData["Success"] = "درخواست با موفقیت حذف شد.";
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = "خطا در انجام عملیات";
        //    }
        //    return RedirectToPage("Request");
        //}
    }
}
