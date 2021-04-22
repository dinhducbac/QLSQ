using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLGiaDinhSQ
{
    public class QLGiaDinhSQDeleteRequest
    {
        [Display(Name = "ID quản lý gia đình sĩ quan")]
        public int IDQLGDSQ { get; set; }
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name = "Họ tên sĩ quan")]
        public string HoTenSQ { get; set; }
        [Display(Name = "Quan hệ")]
        public string QuanHe { get; set; }
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
    }
}
