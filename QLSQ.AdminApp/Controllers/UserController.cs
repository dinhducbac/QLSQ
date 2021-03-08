using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.System.Users;

namespace QLSQ.AdminApp.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserApiClient _userApiClient;

        public UserController(IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
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
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var token = await _userApiClient.Authentication(request);

            return View(token);
        }
    }
}