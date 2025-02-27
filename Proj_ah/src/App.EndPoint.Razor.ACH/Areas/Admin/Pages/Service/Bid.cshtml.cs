
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using Microsoft.AspNetCore.Authorization;

namespace App.EndPoint.Razor.ACH.Admin.Pages.Service
{
    [Authorize(Roles = "Admin")]
    public class BidModel : PageModel
    {
        private readonly ISuggestionAppServices _suggestionAppServices;

        public BidModel(ISuggestionAppServices suggestionAppServices)
        {
            _suggestionAppServices = suggestionAppServices;
        }

        [BindProperty]
        public List<SuggestionDTO> Bids { get; set; }

        [BindProperty]
        //public SoftDeleteDto Delete { get; set; }
        public int Delete { get; set; }

        [BindProperty]
        public SuggestionStatusDto Status { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Bids = await _suggestionAppServices.GetAllSuggestion(cancellationToken);
        }

        public async Task<IActionResult> OnPostChangeStatusBid(CancellationToken cancellationToken)
        {
            try
            {
                await _suggestionAppServices.ChangeSuggestionStatus(Status, cancellationToken);
                TempData["Success"] = "وضعیت پیشنهاد با موفقیت تغییر یافت.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("Bid");
        }

        public async Task<IActionResult> OnPostDeleteBid(CancellationToken cancellationToken)
        {
            try
            {
                await _suggestionAppServices.DeleteSuggestionById(Delete, cancellationToken);
                TempData["Success"] = "پیشنهاد با موفقیت حذف شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("Bid");
        }
    }
}
