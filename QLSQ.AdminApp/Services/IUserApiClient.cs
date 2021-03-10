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
        Task<String> Authentication(LoginRequest request);
        Task<PageResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request);
    }
}
