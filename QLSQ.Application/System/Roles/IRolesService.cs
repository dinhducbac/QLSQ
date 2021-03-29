using QLSQ.ViewModel.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.System.Roles
{
     public interface IRolesService
    {
        Task<List<RolesViewModel>> GetAll();
    }
}
