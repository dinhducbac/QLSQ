using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSQ.ViewModel.Common;
using QLSQ.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<APIResult<string>> Authentication(LoginRequest request);
        Task<APIResult<string>> CreateUser(CreateUserRequest request);
        Task<APIResult<string>> UpdateUser(Guid ID,UpdateUserRequest request);
        Task<APIResult<string>> DeleteUser(Guid ID);
        Task<APIResult<PageResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request);
        Task<APIResult<UserViewModel>> GetUserByID(Guid Id);
    }
}
