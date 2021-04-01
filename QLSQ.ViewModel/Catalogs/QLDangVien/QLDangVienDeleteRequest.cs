using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLDangVien
{
    public class QLDangVienDeleteRequest
    {
        [Display(Name = "ID quản lí dảng viên")]
        public int IDQLDV { get; set; }
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name = "Họ và tên")]
        public string HoTen { get; set; }
        [Display(Name = "Ngày vào đảng")]
        public DateTime NgayVaoDang { get; set; }
        [Display(Name = "Nơi vào đảng")]
        public string NoiVaoDang { get; set; }
    }
}
