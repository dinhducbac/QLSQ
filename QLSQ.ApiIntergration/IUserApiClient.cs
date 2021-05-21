
using QLSQ.ViewModel.Common;
using QLSQ.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public interface IUserApiClient
    {
        public Task<APIResult<string>> Authentication(LoginRequest request);
        public Task<APIResult<string>> AuthenticateForWebApp(LoginRequest request); 
        public Task<APIResult<string>> CreateUser(CreateUserRequest request);
        public Task<APIResult<string>> UpdateUser(Guid ID, UpdateUserRequest request);
        public Task<APIResult<string>> DeleteUser(Guid ID);
        public Task<APIResult<PageResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request);
        public Task<APIResult<UserViewModel>> GetUserByID(Guid Id);
        public Task<APIResult<UserViewModel>> DetailUser(Guid Id);
        public Task<APIResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
        public Task<APIResult<List<UserViewModel>>> GetAllUser();
        public Task<APIResult<List<UserViewModel>>> GetListUserAutocomplete(string prefix);
    }
}
