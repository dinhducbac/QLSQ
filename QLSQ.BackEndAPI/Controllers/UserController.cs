using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.System.Users;
using QLSQ.ViewModel.System.Users;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authencate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var resulttoken = await _userService.Authenticate(request);
            if (string.IsNullOrEmpty(resulttoken))
                return BadRequest("Username hoặc Password không đúng");
            return Ok(new { token = resulttoken });
        }
      
    }
}