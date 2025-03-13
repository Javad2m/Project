using App.Domain.Core.Contracts.AppServices;
using App.EndPoint.API.ACH.ActionFillter;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.API.ACH.Controllers;


    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(FillterApiKey))]
    public class ListRequestController : ControllerBase
    {
        private readonly IRequestAppServices _appService;

        public ListRequestController(IRequestAppServices appService)
        {
            _appService = appService;
        }

        [HttpGet("GetRequests")]
        public async Task<IActionResult> GetRequests(CancellationToken cancellationToken)
        {
            var requests = await _appService.GetAllRequests(cancellationToken);

            if (requests == null || requests.Count == 0)
                return NotFound(new { message = "هیچ درخواستی یافت نشد." });

            return Ok(requests);
        }
    }

