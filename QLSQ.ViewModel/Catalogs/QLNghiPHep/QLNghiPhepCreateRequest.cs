using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLNghiPHep
{
    public class QLNghiPhepCreateRequest
    {
        [Display(Name ="Họ tên sĩ quan")]
        public string HoTen { get; set; }
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name = "Thời gian bắt đầu nghỉ phép")]
        public DateTime ThoiGianBDNP { get; set; }
        [Display(Name = "Thời gian kết thúc nghỉ phép")]
        public DateTime ThoiGianKTNP { get; set; }
    }
}
