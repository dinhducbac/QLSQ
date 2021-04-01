using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.SiQuan
{
    public class SiQuanDeleteRequest
    {
        [Display(Name ="ID Sĩ Quan")]
        public int IDSQ { get; set; }
        [Display(Name = "Họ và tên")]
        public string HoTen { get; set; }
    }
}
