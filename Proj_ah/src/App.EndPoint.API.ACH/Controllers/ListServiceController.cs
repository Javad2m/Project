using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Entities.Configs;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.API.ACH.Controllers;


    [ApiController]
    [Route("api/[controller]")]
    public class ListServiceController : ControllerBase
    {
        private readonly ICategoryAppServices _categoryAppService;
        private readonly ISubCategoryAppServices _subCategoryAppService;
        private readonly IServiceSubCategoryAppServices _homeServiceAppService;
        private readonly string _apiKey;

        public ListServiceController(ICategoryAppServices categoryAppService, ISubCategoryAppServices subCategoryAppService, IServiceSubCategoryAppServices homeServiceAppService, SiteSettings siteSetting)
        {
            _categoryAppService = categoryAppService;
            _subCategoryAppService = subCategoryAppService;
            _homeServiceAppService = homeServiceAppService;
            _apiKey = siteSetting.ApiKey;
        }

        private bool ValidateApiKey(string? apikey) => !string.IsNullOrWhiteSpace(apikey) && apikey == _apiKey;

        private IActionResult ValidateRequest(string? apikey)
        {
            if (!ValidateApiKey(apikey))
                return Unauthorized("شما دسترسی به این ای پی ای را ندارید.");

            return null;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories([FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            var validationResponse = ValidateRequest(apikey);
            if (validationResponse != null) return validationResponse;

            var categories = await _categoryAppService.GetAllCategories(cancellationToken);
            return Ok(categories);
        }

        [HttpGet("GetSubCategories")]
        public async Task<IActionResult> GetSubCategories([FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            var validationResponse = ValidateRequest(apikey);
            if (validationResponse != null) return validationResponse;

            var subCategories = await _subCategoryAppService.GetAllSub(cancellationToken);
            return Ok(subCategories);
        }

        [HttpGet("GetHomeServices")]
        public async Task<IActionResult> GetHomeServices([FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            var validationResponse = ValidateRequest(apikey);
            if (validationResponse != null) return validationResponse;

            var homeServices = await _homeServiceAppService.GetAllServices(cancellationToken);
            return Ok(homeServices);
        }
    }

