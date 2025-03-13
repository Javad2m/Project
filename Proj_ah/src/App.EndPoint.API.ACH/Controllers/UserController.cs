using App.Domain.Core.Entities.Configs;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;

namespace App.EndPoint.API.ACH.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    private readonly IAccountAppServices _appService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly string _apiKey;

    public UserController(IAccountAppServices appService, UserManager<ApplicationUser> userManager, SiteSettings siteSetting)
    {
        _appService = appService;
        _userManager = userManager;
        _apiKey = siteSetting.ApiKey;
    }

    private bool ValidateApiKey(string? apikey) => !string.IsNullOrWhiteSpace(apikey) && apikey == _apiKey;

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] AppliccationUserDTO? register, [FromHeader] string? apikey, CancellationToken cancellationToken)
    {
        if (!ValidateApiKey(apikey))
            return Unauthorized(new { message = "شما دسترسی به این ای پی آی ندارید" });

        if (register is null)
            return BadRequest(new { message = "داده‌های کاربر نمی‌توانند خالی باشند" });

        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return BadRequest(new { message = "اطلاعات وارد شده صحیح نیست", errors });
        }

        //if (register.Password != register.ConfirmPassword)
        //    return BadRequest(new { message = "رمز عبور و تکرار رمز عبور باید یکسان باشند" });

        var existingUser = await _userManager.FindByNameAsync(register.Email);
        if (existingUser != null)
            return Conflict(new { message = "این نام کاربری قبلاً ثبت شده است" });

        var userId = await _appService.Register(register, cancellationToken);

        return Ok(new { message = "کاربر با موفقیت اضافه شد", register.Email});
    }
}
