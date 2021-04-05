using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QuanHam
{
    public class QuanHamDeleteRequest
    {
        [Display(Name = "ID quân hàm")]
        public int IDQH { get; set; }
        [Display(Name = "Tên quân hàm")]
        public string TenQH { get; set; }
    }
}
