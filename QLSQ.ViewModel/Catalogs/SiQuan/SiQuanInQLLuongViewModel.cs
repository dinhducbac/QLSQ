using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.SiQuan
{
    public class SiQuanInQLLuongViewModel
    {
        [Display(Name = "Họ tên sĩ quan")]
        public string HoTen { get; set; }
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name = "ID quân hàm")]
        public int IDQH {get;set;}
        [Display(Name = "Tên quân hàm")]
        public string TenQH { get; set; }
        [Display(Name = " ID Hệ số lương")]
        public int IDHeSoLuongQH { get; set; }
        [Display(Name ="Hệ số lương")]
        public float HeSoLuongQH { get; set; }
        [Display(Name = "ID chức vụ")]
        public int IDCV { get; set; }
        [Display(Name = "Tên chức vụ")]
        public string TenCV { get; set; }
        [Display(Name = "ID Hệ số phụ cấp")]
        public int IDHeSoPhuCapCV { get; set; }
        [Display(Name = "Hệ số phụ cấp")]
        public float HeSoPhuCapCV { get; set; }
        [Display(Name = "ID Lương cơ bản")]
        public int IDLuongCB { get; set; }
        [Display(Name = "Lương cơ bản")]
        public float LuongCB { get; set; }
        [Display(Name = "Lương")]
        public ulong Luong { get; set; }
    }
}
