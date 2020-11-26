using QLSQ.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
