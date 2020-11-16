using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public String Mota { get; set; }
    }
}
