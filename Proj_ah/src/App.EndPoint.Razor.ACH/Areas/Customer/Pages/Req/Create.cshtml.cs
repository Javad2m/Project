using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.EndPoint.Razor.ACH.Areas.Customer.Pages.Req
{

    [Authorize(Roles = "Customer")]
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
