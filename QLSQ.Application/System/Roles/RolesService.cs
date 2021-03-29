using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QLSQ.Data.Entities;
using QLSQ.ViewModel.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.Application.System.Roles
{
    public class RolesService :IRolesService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RolesService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RolesViewModel>> GetAll()
        {
            var roles = await _roleManager.Roles.Select(x => new RolesViewModel()
            {
                ID = x.Id,
                Name = x.Name,
                Description = x.Mota
            }).ToListAsync();
            return roles;
        }
    }
}
