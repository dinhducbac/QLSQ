using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.System.Users;
using QLSQ.ViewModel.System.Users;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
            string test = resulttoken.ResultObj;
            if (string.IsNullOrEmpty(resulttoken.ResultObj))
                return BadRequest(resulttoken.Message);
            return Ok(resulttoken);
        }
        [HttpPost("createuser")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.CreateUser(request);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
        //put http://localhost/api/user/id
        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.UpdateUser(id,request);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteUser(id);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
        //http://localhost/api/user/paging?pageindex=1&pagesize=10&keyword=
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]GetUserPagingRequest request)
        {
            var user = await _userService.GetUserPaging(request);
            return Ok(user);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByID(Guid id)
        {
            var user = await _userService.GetUserByID(id);
     
            return Ok(user);
        }
        [HttpGet("{id}/detail")]
        public async Task<IActionResult> DetailUser(Guid id)
        {
            var user = await _userService.DetailUser(id);
            return Ok(user);
        }
        //put http://localhost/api/user/id
        [HttpPut("{id}/roles")]
        public async Task<IActionResult> RoleAssign(Guid id, [FromBody] RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.RoleAssign(id, request);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("getalluser")]
        public async Task<IActionResult> GetAllUser()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.GetAllUser();
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("getlistuserautocomplete")]
        public async Task<IActionResult> GetListUserAutoComplete(string prefix)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.GetListUserAutocomplete(prefix);
            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }
    }
}