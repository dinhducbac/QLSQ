using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.LuongCoBan
{
    public class LuongCoBanUpdateRequest
    {
        [Display(Name = "ID lương cơ bản")]
        public int IDLuongCB { get; set; }
        [Display(Name = "Lương cơ bản")]
        public ulong LuongCB { get; set; }
    }
}
