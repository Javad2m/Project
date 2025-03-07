using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using App.Domain.Core.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoint.Razor.ACH.Areas.Customer.Pages.Com
{

    [Authorize(Roles = "Customer")]
    public class CommentModel : PageModel
    {

        private readonly ICommentAppServices _commentAppServices;
        private readonly IRequestAppServices _requestAppServices;

        public CommentModel(ICommentAppServices commentAppServices, IRequestAppServices requestAppServices)
        {
            _commentAppServices = commentAppServices;
            _requestAppServices = requestAppServices;
        }

        [BindProperty]
        public List<RequestDTO> RequestDTOs { get; set; }


        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userCustomerId").Value);
            RequestDTOs = (await _requestAppServices.GetRequestByCI(userId, cancellationToken))
                                        .Where(r => r.Status == RequestStatusEnum.Done)
                                        .ToList();


        }
    }
}
