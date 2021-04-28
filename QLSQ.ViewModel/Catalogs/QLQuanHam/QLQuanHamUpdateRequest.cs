using QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam;
using QLSQ.ViewModel.Catalogs.QuanHam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLQuanHam
{
    public class QLQuanHamUpdateRequest
    {
        [Display(Name ="ID quản lý quân hàm của sĩ quan")]
        public int IDQLQH { get; set; }
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name ="Họ tên sĩ quan")]
        public string HoTen { get; set; }
        [Display(Name = "Quân hàm")]
        public int IDQH { get; set; }
        [Display(Name = "Tên hệ số lương")]
        public int IDHeSoLuongQH { get; set; }
        [Display(Name = "Hệ số lương")]
        public float HeSoLuong { get; set; }
        public List<QuanHamViewModel> quanHamViewModels { get; set; }
        public List<HeSoLuongTheoQuanHamViewModel> heSoLuongTheoQuanHamViewModels { get; set; }
    }
}
