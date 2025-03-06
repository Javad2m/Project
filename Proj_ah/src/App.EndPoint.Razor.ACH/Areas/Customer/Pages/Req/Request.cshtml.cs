using App.Domain.AppServices;
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoint.Razor.ACH.Areas.Customer.Pages.Req
{
    [Authorize(Roles = "Customer")]
    public class RequestModel : PageModel
    {
        private readonly IRequestAppServices _requestAppServices;

        public RequestModel(IRequestAppServices requestAppServices)
        {
            _requestAppServices = requestAppServices;
        }


        [BindProperty]
        public List<RequestDTO> Request { get; set; }
        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
            try
            {
                var userCustomerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId")?.Value ?? "0");
                Request = await _requestAppServices.GetRequestByCI(userCustomerId, cancellationToken);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $" error : {ex.Message}");
            }
        }


        public async Task<IActionResult> OnPostAcceptRequest(int id, int expertId, CancellationToken cancellationToken)
        {
            try
            {
                var userCustomerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId")?.Value ?? "0");
                await _requestAppServices.AcceptExpert(id, userCustomerId, cancellationToken);
                TempData["Success"] = "??????? ????? ??";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "??? ?? ????? ???????";
            }
            return RedirectToPage("ListRequest");
        }

        public async Task<IActionResult> OnPostDoneRequest(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _requestAppServices.DoneRequest(id, cancellationToken);
                TempData["Success"] = "?? ?????? ???? ??";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "??? ?? ????? ??????";
            }
            return RedirectToPage("ListRequest");
        }

        public async Task<IActionResult> OnPostCancellRequest(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _requestAppServices.CancellRequest(id, cancellationToken);
                TempData["Success"] = "?? ?????? ???? ??";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "??? ???? ???";
            }
            return RedirectToPage("ListRequest");
        }

        public async Task<IActionResult> OnPostDeleteRequest(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _requestAppServices.DeleteRequest(id, cancellationToken);  
                TempData["Success"] = "Delete Succec";
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Field: {ex.Message}";
                return RedirectToPage();
            }
        }

    }
}
