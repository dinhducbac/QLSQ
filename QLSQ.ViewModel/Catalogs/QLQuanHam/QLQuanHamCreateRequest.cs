using QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam;
using QLSQ.ViewModel.Catalogs.QuanHam;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLQuanHam
{
    public class QLQuanHamCreateRequest
    {
        public string HoTen { get; set; }
        public int IDSQ { get; set; }
        public int IDQH { get; set; }
        public int IDHeSoLuongQH { get; set; }
        public List<QuanHamViewModel> quanHamViewModels { get; set; }
        public List<HeSoLuongTheoQuanHamViewModel> heSoLuongTheoQuanHamViewModels { get; set; }
    }
}
