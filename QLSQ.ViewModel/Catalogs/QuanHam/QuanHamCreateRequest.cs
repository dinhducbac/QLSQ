using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QuanHam
{
    public class QuanHamCreateRequest
    {
        [Display(Name ="Tên quân hàm")]
        public string TenQH { get; set; }
    }
}
