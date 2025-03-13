using App.Domain.Core.Entities.Configs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.EndPoint.API.ACH.ActionFillter;

public class FillterApiKey : IActionFilter
{
    private const string ApiKeyHeaderName = "apikey";
    public void OnActionExecuted(ActionExecutedContext context)
    {
        var siteSetting = context.HttpContext.RequestServices.GetService<SiteSettings>();
        var apiKey = context.HttpContext.Request.Headers[ApiKeyHeaderName].ToString();

        if (string.IsNullOrWhiteSpace(apiKey) || siteSetting == null || apiKey != siteSetting.ApiKey)
        {
            context.Result = new UnauthorizedObjectResult(new { message = "شما دسترسی به این ای پی آی را ندارید." });
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
}
