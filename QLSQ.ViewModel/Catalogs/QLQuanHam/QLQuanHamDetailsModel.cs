using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLQuanHam
{
    public class QLQuanHamDetailsModel
    {
        [Display(Name = "ID quản lý quân hàm")]
        public int IDQLQH { get; set; }
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name = "Họ tên sĩ quan")]
        public string HoTen { get; set; }
        [Display(Name ="ID quân hàm")]
        public int IDQH { get; set; }
        [Display(Name = "Quân hàm")]
        public string TenQH { get; set; }
        [Display(Name = "ID hệ số lương")]
        public int IDHeSoLuongQH { get; set; }
        [Display(Name = "Tên hệ số lương quân hàm")]
        public string TenHeSoLuongQH { get; set; }
        [Display(Name = "Hệ số lương")]
        public float HeSoLuong { get; set; }
    }
}
