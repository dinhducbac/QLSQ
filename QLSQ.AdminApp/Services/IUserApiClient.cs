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
    }
}
