using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam
{
    public class HeSoLuongTheoQuanHamUpdateRequest
    {
        [Display(Name = "ID hệ số lương")]
        public int IDHeSoLuongQH { get; set; }
        [Display(Name = "ID quân hàm")]
        public int IDQH { get; set; }
        [Display(Name = "Tên quân hàm")]
        public string TenQH { get; set; }
        [Display(Name = "Hệ số lương")]
        public float HeSoLuong { get; set; }
    }
}
