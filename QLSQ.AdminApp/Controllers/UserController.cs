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
using Microsoft.Extensions.Configuration.Ini;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.System.Users;

namespace QLSQ.AdminApp.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserApiClient _userApiClient;
        public readonly IConfiguration _configuration;

        public UserController(IUserApiClient userApiClient, IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> IndexAsync(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetUserPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize  = pageSize    
            };
            var data = await _userApiClient.GetUserPaging(request);
            var test = data.ResultObj;
            return View(data.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> LoginAsync()
        {
           await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var token = await _userApiClient.Authentication(request);
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
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        public async Task<IActionResult> CreateUser()
        {
            return View();
        }
       
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _userApiClient.DetailUser(id);
            if (result.IsSuccessed)
            {
                return View(result.ResultObj);
            }
            return BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _userApiClient.GetUserByID(id);
            if (result.IsSuccessed)
            {
                var user = result.ResultObj;
                var updaterequest = new UpdateUserRequest
                {
                    ID = id,
                    Email = user.Email,
                    Password = user.Password,
                    PhoneNumber = user.PhoneNumber
                };
                return View(updaterequest);
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _userApiClient.UpdateUser(request.ID, request);
            if (result.IsSuccessed)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _userApiClient.CreateUser(request);
            if (result.ResultObj.Equals("Tạo tài khoản thành công!"))
                return RedirectToAction("Index");
            ModelState.AddModelError("",result.Message);
            return View(result);
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
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userApiClient.GetUserByID(id);
            if (result.IsSuccessed)
            {
                var user = result.ResultObj;
                var deleterequest = new DeleteUserRequest
                {
                    ID = id
                };
                return View(deleterequest);
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteUserRequest request) 
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _userApiClient.DeleteUser(request.ID);
            if (result.IsSuccessed)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(result);
        }
    }
}