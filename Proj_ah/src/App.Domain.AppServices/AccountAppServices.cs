using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices;

public class AccountAppServices : IAccountAppServices
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ICustomerServices _customerService;
    private readonly IExpertServices _expertService;
    private readonly IAdminServices _adminServices;

    public AccountAppServices(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ICustomerServices customerServices, IExpertServices expertServices, IAdminServices adminServices)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _customerService = customerServices;
        _expertService = expertServices;
        _adminServices = adminServices;

    }

    public async Task<bool> Login(string email, string password, CancellationToken cancellationToken)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, true, lockoutOnFailure: false);

        return result.Succeeded;
    }

    public async Task<List<IdentityError>> Register(AppliccationUserDTO model, CancellationToken cancellationToken)
    {
        try
        {


            string role = string.Empty;


            var user = new ApplicationUser();


            if (model.Role == "Expert")
            {
                role = "Expert";

                user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Expert = new Expert()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Wallet = 0,
                        Email = model.Email,
                        CreatedAt = DateTime.UtcNow,


                    }
                };
            }

            if (model.Role == "Customer")
            {
                role = "Customer";

                user = new ApplicationUser
                {

                    Email = model.Email,
                    UserName = model.Email,
                    Customer = new Customer()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Wallet = 0,
                        Mail = model.Email,
                        CreatedAt = DateTime.UtcNow

                    }
                };
            }

            if (model.Role == "Admin")
            {
                role = "Admin";

                user = new ApplicationUser
                {

                    Email = model.Email,
                    UserName = model.Email,
                    Customer = new Customer()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Wallet = 0,
                        Mail = model.Email,
                        CreatedAt = DateTime.UtcNow

                    }
                };
            }


            var result = await _userManager.CreateAsync(user, model.Password);


            if (model.Role == "Customer")
            {
                var userCustomerId = user.Customer!.Id;
                await _userManager.AddClaimAsync(user, new Claim("userCustomerId", userCustomerId.ToString()));
            }

            if (model.Role == "Expert")
            {
                var userExpertId = user.Expert!.Id;
                await _userManager.AddClaimAsync(user, new Claim("userExpertId", userExpertId.ToString()));
            }

            if (model.Role == "Admin")
            {
                var userAdminId = user.Admin!.Id;
                await _userManager.AddClaimAsync(user, new Claim("userAdminId", userAdminId.ToString()));
            }
            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, role);

            return (List<IdentityError>)result.Errors;
        }
        catch (Exception ex)
        {
            throw new Exception($": {ex.Message}");
        }
    }
}

//    public async Task<List<IdentityError>> Register(AppliccationUserDTO model, CancellationToken cancellationToken)
//    {
//        var role = string.Empty;

//        var user = CreateUser();

//        user.UserName = model.Email;
//        user.Email = model.Email;


//        if (model.Role == "Expert")
//        {
//            role = "Expert";
//            user.Expert = new Expert()
//            {
//                FirstName = model.FirstName,
//                LastName = model.LastName,
//                Wallet = 0,
//                Email = model.Email,
//                CreatedAt = DateTime.UtcNow,


//            };
//        }


//        var result = await _userManager.CreateAsync(user, model.Password);

//        if (model.Role == "Expert")
//        {
//            var userExpertId = user.Expert!.Id;
//            await _userManager.AddClaimAsync(user, new Claim("userExpertId", userExpertId.ToString()));
//        }
//        else
//        {
//            var userCustomerId = user.Customer!.Id;
//            await _userManager.AddClaimAsync(user, new Claim("userCustomerId", userCustomerId.ToString()));
//        }

//        if (result.Succeeded)
//        {
//            await _userManager.AddToRoleAsync(user, role);



//        }
//        return (List<IdentityError>)result.Errors;
//    }

//    private ApplicationUser CreateUser()
//    {
//        try
//        {
//            return Activator.CreateInstance<ApplicationUser>();
//        }
//        catch
//        {
//            throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
//            $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively ");
//        }
//    }
//}
