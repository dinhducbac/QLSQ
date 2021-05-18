using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QLSQ.Data.EF;
using QLSQ.Data.Entities;
using QLSQ.Utilities.Exceptions;
using QLSQ.ViewModel.Common;
using QLSQ.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly QL_SiQuanDBContext _context;
        private readonly IConfiguration _config;
        public UserService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, 
             IConfiguration configuration,QL_SiQuanDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = configuration;
            _context = context;
        }
        public async Task<APIResult<string>> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return  new APIErrorResult<string>("Bạn nhập sai tên username");
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if(!result.Succeeded)
            {
                 return new APIErrorResult<string>("Bạn nhập sai mật khẩu! Đăng nhập thất bại");
            }
            var role = await _userManager.GetRolesAsync(user);
            var roleName = role[0].ToString();
            if(roleName != "admin")
            {
                return new APISuccessedResult<string>("Error Role!");
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.SerialNumber, user.Id.ToString()),
                new Claim(ClaimTypes.Role, string.Join(";",role))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Token:Issuer"],
                _config["Token:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new APISuccessedResult<string>(tokenString);
        }

        public async Task<APIResult<string>> CreateUser(CreateUserRequest request)
        {
            var username = await _userManager.FindByNameAsync(request.Username);
            if (username != null)
            {
                return new APIErrorResult<string>("Username đã tồn tại!");
            }
            else
            {
                var user = new AppUser()
                {
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    UserName = request.Username
                };
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    return new APISuccessedResult<string>("Tạo tài khoản thành công!");
                }
                else
                {
                    return new APIErrorResult<string>("Tạo tài khoản thất bại!");
                }
            }

        }
        public async Task<APIResult<string>> UpdateUser(Guid id,UpdateUserRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            user.Email = request.Email;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordConfirm);
            user.PhoneNumber = request.PhoneNumber;
            await _userManager.UpdateAsync(user);
            return new APISuccessedResult<string>("Cập nhật thành công!");
        }

        public async Task<APIResult<PageResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.UserName.Contains(request.keyword) || 
                                x.Email.Contains(request.keyword));

            }
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                        .Take(request.pageSize)
                        .Select(x => new UserViewModel()
                        {
                            ID = x.Id,
                            Username = x.UserName,
                            Password = x.PasswordHash,
                            PhoneNumber = x.PhoneNumber,
                            Email = x.Email
                        }).ToListAsync();
            var pageResult = new PageResult<UserViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.pageIndex,
                PageSize = request.pageSize,
                Items = data
            };
            return new  APISuccessedResult<PageResult<UserViewModel>>(pageResult);
        }

        public async Task<APIResult<UserViewModel>> GetUserByID(Guid ID)
        {
            var user = await _userManager.FindByIdAsync(ID.ToString());
            var roles = await _userManager.GetRolesAsync(user);
            var uservm = new UserViewModel
            {
                ID = user.Id,
                Email = user.Email,
                Username = user.UserName,
                Password = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,
                Roles = roles
               
            };
            return new APISuccessedResult<UserViewModel>(uservm);
        }

        public async Task<APIResult<string>> DeleteUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var result = await _userManager.DeleteAsync(user);
            if(result.Succeeded)
                return new APISuccessedResult<string>("Xóa tài khoản thành công!");
            return new APIErrorResult<string>("Xóa tài khoản khong thành công!");
        }

        public async Task<APIResult<UserViewModel>> DetailUser(Guid ID)
        {
            var user = await _userManager.FindByIdAsync(ID.ToString());
            var uservm = new UserViewModel
            {
                ID = user.Id,
                Email = user.Email,
                Username = user.UserName,
                Password = user.PasswordHash,
                PhoneNumber = user.PhoneNumber
            };
           
            return new APISuccessedResult<UserViewModel>(uservm);
        }

        public async Task<APIResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if(user == null)
            {
                return new APIErrorResult<bool>("Tài khoản không tồn tại"); 
            }
            var removeRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
            foreach (var roleName in removeRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName)==true)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName);
                }
            }
            await _userManager.RemoveFromRolesAsync(user, removeRoles);
            var addRoles = request.Roles.Where(x => x.Selected == true).Select(x => x.Name).ToList();
            foreach (var roleName in addRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == false)
                {
                    await _userManager.AddToRolesAsync(user, addRoles);
                }
            }

            return new APISuccessedResult<bool>(); 
        }

        public async Task<APIResult<List<UserViewModel>>> GetAllUser()
        {
            List<UserViewModel> listuser = new List<UserViewModel>();
            var query = _userManager.Users;
            foreach (var user in query)
            {
                var uservm = new UserViewModel()
                {
                    ID = user.Id,
                    Username = user.UserName
                };
                listuser.Add(uservm);
            }
            return new APISuccessedResult<List<UserViewModel>>(listuser);
        }

        public async Task<APIResult<List<UserViewModel>>> GetListUserAutocomplete(string prefix)
        {
            List<UserViewModel> listuser = new List<UserViewModel>();
            var query = from user in _userManager.Users
                        where !_context.SiQuans.Any(x => x.UserId == user.Id)
                        select user;
            if (!string.IsNullOrEmpty(prefix))
            {
                 query = from user in _userManager.Users
                            where !_context.SiQuans.Any(x => x.UserId == user.Id) && (user.UserName.StartsWith(prefix) ||
                            user.UserName.Contains(prefix))
                            select user;
            }
            
            foreach(var data in query)
            {
                var userViewModel = new UserViewModel()
                {
                    ID = data.Id,
                    Username = data.UserName
                };
                listuser.Add(userViewModel);
            }
            return new APISuccessedResult<List<UserViewModel>>(listuser);
        }
    }
}
