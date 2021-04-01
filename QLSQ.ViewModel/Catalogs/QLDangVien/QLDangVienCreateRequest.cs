using QLSQ.ViewModel.Catalogs.SiQuan;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLDangVien
{
    public class QLDangVienCreateRequest
    {
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name = "Ngày vào đảng")]
        public DateTime NgayVaoDang { get; set; }
        [Display(Name = "Nơi vào đảng")]
        public string NoiVaoDang { get; set; }
        public List<SiQuanViewModel> siQuanViewModels { get; set; }
    }
}
