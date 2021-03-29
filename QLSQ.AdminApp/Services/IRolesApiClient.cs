using QLSQ.ViewModel.Common;
using QLSQ.ViewModel.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public interface IRolesApiClient
    {
        Task<APIResult<List<RolesViewModel>>> GetAll();
    }
}
