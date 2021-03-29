﻿using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.System.Users
{
    public class RoleAssignRequest
    {
        public Guid ID { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
