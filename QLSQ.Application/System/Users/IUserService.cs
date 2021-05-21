using Microsoft.AspNetCore.Mvc.RazorPages;
using QLSQ.ViewModel.Common;
using QLSQ.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.System.Users
{
    public interface IUserService
    {
        Task<APIResult<string>> Authenticate(LoginRequest request);
        Task<APIResult<string>> AuthenticateForWebApp(LoginRequest request);
        Task<APIResult<string>> CreateUser(CreateUserRequest request);
        Task<APIResult<PageResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request);
        Task<APIResult<string>> UpdateUser(Guid Id,UpdateUserRequest request);
        Task<APIResult<UserViewModel>> GetUserByID(Guid ID);
        Task<APIResult<string>> DeleteUser(Guid id);
        Task<APIResult<UserViewModel>> DetailUser(Guid ID);
        Task<APIResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
        Task<APIResult<List<UserViewModel>>> GetAllUser();
        Task<APIResult<List<UserViewModel>>> GetListUserAutocomplete(string prefix);

    }
}
