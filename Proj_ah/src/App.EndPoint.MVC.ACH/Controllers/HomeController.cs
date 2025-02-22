using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using App.EndPoint.MVC.ACH.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.EndPoint.MVC.ACH.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IAccountAppServices _accountAppServices;



        public HomeController(ILogger<HomeController> logger, IAccountAppServices accountAppServices)
        {
            _logger = logger;
            _accountAppServices = accountAppServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult Login()
        {
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> LoginUser(string Email, string Password, CancellationToken cancellationToken)
        {
            
            var check = await _accountAppServices.Login(Email, Password, cancellationToken);

            if (check)
            {
                return RedirectToAction("Index", "Transaction");
            }
            else
            {

                TempData["ErrorMessage"] = "??? ???? ?? ????? ???? ???? ????.";
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUser(AppliccationUserDTO model, CancellationToken cancellationToken)
        {
            //if (!ModelState.IsValid)
            //{
            //    var check = _accountAppServices.Register(model, cancellationToken);
            //}
            
            //TempData["ErrorMessage"] = "??? ???? ?? ????? ???? ???? ????.";
            //return RedirectToAction("Login");

            var result = await _accountAppServices.Register(model, cancellationToken);
            if (result.Count == 0)
            {
                TempData["Success"] = "??????? ?? ?????? ????? ??.";
                return LocalRedirect("~/Account/Login");
            }

            foreach (var error in result)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return RedirectToAction("Login");
        }
    }
}
