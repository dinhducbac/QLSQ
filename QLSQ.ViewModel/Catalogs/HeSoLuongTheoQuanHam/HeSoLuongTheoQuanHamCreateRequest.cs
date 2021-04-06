using QLSQ.ViewModel.Catalogs.QuanHam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam
{
    public class HeSoLuongTheoQuanHamCreateRequest
    {
        [Display(Name = "ID quân hàm")]
        public int IDQH { get; set; }
        [Display(Name = "Hệ số lương")]
        public float HeSoLuong { get; set; }
        public List<QuanHamViewModel> quanHamViewModels { get; set; }
    }
}
