using App.Domain.Core.Entities.Configs;

namespace App.EndPoint.API.ACH.Middlewares;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly SiteSettings _siteSettings;

    public ApiKeyMiddleware(RequestDelegate next, SiteSettings siteSettings)
    {
        _next = next;
        _siteSettings = siteSettings;
    }
}
