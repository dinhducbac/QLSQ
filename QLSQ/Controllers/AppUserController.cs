using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using QLSQ.ApiIntergration;
using QLSQ.ViewModel.System.Users;
using QLSQ.WebApp.Models;

namespace QLSQ.WebApp.Controllers
{
    public class AppUserController : Controller
    {
        public readonly IUserApiClient _userApiClient;
        public readonly IConfiguration _configuration;
        public readonly ISiQuanApiClient _siQuanApiClient;

        public AppUserController(IUserApiClient userApiClient, IConfiguration configuration, ISiQuanApiClient siQuanApiClient)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
            _siQuanApiClient = siQuanApiClient;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login( LoginRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var token = await _userApiClient.AuthenticateForWebApp(request);
            if(token.ResultObj == null)
            {
                ViewBag.Login = false;
                ViewBag.LoginMessage = "Bạn đã đăng nhập sai tài khoản hoặc mật khẩu!";
                return View();
            }
            var userPricipal = this.ValidateToken(token.ResultObj);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = false
            };
            HttpContext.Session.SetString("Token", token.ResultObj);
            await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                   userPricipal,
                    authProperties);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "AppUser");
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;
            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();
            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Token:Issuer"];
            validationParameters.ValidIssuer = _configuration["Token:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);
            return principal;
        }
        [HttpGet]
        public async Task<IActionResult> Profile(string UserName)
        {
            var profile = await _siQuanApiClient.GetProfileByUserName(UserName);          
            var showProfileVM = new ShowProfileViewModel()
            {
                ProfileViewModel = profile.ResultObj
            };
            if (profile.ResultObj.ImagePath == null)
                profile.ResultObj.ImagePath = "underfind.png";
            var infoOfJobOfSiQuan = await _siQuanApiClient.GetInfoOfJobOfSiQuan(profile.ResultObj.IDSQ);
            showProfileVM.InfoOfJobOfSiQuanViewModel = infoOfJobOfSiQuan.ResultObj;
            return View(showProfileVM);
        }

    }
}