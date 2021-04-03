using Microsoft.AspNetCore.Mvc;
using pShopSolution.AdminApp.Services;
using pShopSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pShopSolution.AdminApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiclient apiclient;
        public UserController(IUserApiclient _apiclient)
        {
            apiclient = _apiclient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        } 

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            var token = await apiclient.Authenticate(loginRequest);
            return View(token);
        }
    }
}
