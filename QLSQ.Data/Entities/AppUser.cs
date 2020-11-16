using Microsoft.AspNetCore.Identity;
using QL_SiQuan.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public SiQuan SiQuan { set; get; }
    }
}
