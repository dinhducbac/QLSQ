using QLSQ.ViewModel.Catalogs.QuanHam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam
{
    public class HeSoLuongTheoQuanHamCreateRequest
    {
        public int IDQH { get; set; }
        public float HeSoLuong { get; set; }
        public List<QuanHamViewModel> quanHamViewModels { get; set; }
    }
}
