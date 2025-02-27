
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
    public class CommentModel : PageModel
    {
        private readonly ICommentAppServices _commentAppService;

        public CommentModel(ICommentAppServices commentAppService)
        {
            _commentAppService = commentAppService;
        }

        [BindProperty]
        public List<CommentDTO?> Comments { get; set; }

        [BindProperty]
        //public SoftDeleteDto Delete { get; set; }
        public int Delete { get; set; }

        [BindProperty]
        public CommentAcceptDto Status { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Comments = await _commentAppService.GetAllComments(cancellationToken);
        }

        public async Task<IActionResult> OnPostActiveComment(CancellationToken cancellationToken)
        {
            try
            {
                await _commentAppService.AcceptComment(Status, cancellationToken);
                TempData["Success"] = "وضعیت نظر با موفقیت تغییر یافت.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("Comment");
        }

        public async Task<IActionResult> OnPostDeleteComment(CancellationToken cancellationToken)
        {
            try
            {
                await _commentAppService.DeleteCommentById(Delete, cancellationToken);
                TempData["Success"] = "نظر با موفقیت حذف شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("Comment");
        }
    }
}
