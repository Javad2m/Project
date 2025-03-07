using App.Domain.AppServices;
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using App.Domain.Core.Enum;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security;

namespace App.EndPoint.Razor.ACH.Areas.Customer.Pages.Com
{

    [Authorize(Roles = "Customer")]
    public class CommentModel : PageModel
    {

        private readonly ICommentAppServices _commentAppServices;
        private readonly IRequestAppServices _requestAppServices;
        private readonly ISuggestionAppServices _suggestionAppServices;

        public CommentModel(ICommentAppServices commentAppServices, IRequestAppServices requestAppServices, ISuggestionAppServices suggestionAppServices)
        {
            _commentAppServices = commentAppServices;
            _requestAppServices = requestAppServices;
            _suggestionAppServices = suggestionAppServices;
        }

        [BindProperty]
        public List<RequestDTO> RequestDTOs { get; set; }

        [BindProperty]
        public CommentDTO CommentDTO { get; set; }


        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userCustomerId").Value);
            RequestDTOs = (await _requestAppServices.GetRequestByCI(userId, cancellationToken))
                                        .Where(r => r.Status == RequestStatusEnum.Done)
                                        .ToList();


        }


        public async Task<IActionResult> OnPostCreateComment(CancellationToken cancellationToken, int id)
        {

            try
            {
                await _commentAppServices.CreateComment(CommentDTO, cancellationToken);
                TempData["Success"] = "??? ?? ?????? ????? ??.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "??? ?? ????? ??????";
            }
            return RedirectToPage("Comment");
        }
    }
}
