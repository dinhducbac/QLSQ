using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLChucVu
{
    public class QLChucVuDeleteRequest
    {
        [Display(Name = "ID quản lí chức vụ")]
        public int IDQLCV { get; set; }
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name = "Tên sĩ quan")]
        public string HoTen { get; set; }
        [Display(Name = "ID quân hàm")]
        public int IDQH { get; set; }
        [Display(Name = "Tên quân hàm")]
        public string TenQH { get; set; }
        [Display(Name = "ID bộ phận")]
        public int IDBP { get; set; }
        [Display(Name = "Tên bộ phận")]
        public string TenBP { get; set; }
        [Display(Name = "ID chức vụ")]
        public int IDCV { get; set; }
        [Display(Name = "Tên chức vụ")]
        public string TenCV { get; set; }
    }
}
