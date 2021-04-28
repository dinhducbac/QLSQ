using QLSQ.ViewModel.Catalogs.BoPhan;
using QLSQ.ViewModel.Catalogs.ChucVu;
using QLSQ.ViewModel.Catalogs.QuanHam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLChucVu
{
    public class QLChucVuDetailsViewModel
    {
        [Display(Name = "ID quản lí chức vụ")]
        public int IDQLCV { get; set; }
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name = "Tên sĩ quan")]
        public string HoTen { get; set; }      
        [Display(Name = "ID bộ phận")]
        public int IDBP { get; set; }
        [Display(Name = "Tên bộ phận")]
        public string TenBP { get; set; }
        [Display(Name = "ID chức vụ")]
        public int IDCV { get; set; }
        [Display(Name = "Tên chức vụ")]        
        public string TenCV { get; set; }
        [Display(Name ="Ngày nhận")]
        public DateTime NgayNhan { get; set; }
        [Display(Name ="Hệ số phụ cấp")]
        public float HeSoPhuCap { get; set; }

    }
}
