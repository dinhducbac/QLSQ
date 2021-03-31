using QLSQ.ViewModel.Catalogs.SiQuan;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLDangVien
{
    public class QLDangVienCreateRequest
    {
        public int IDSQ { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public string NoiVaoDang { get; set; }
        public List<SiQuanViewModel> siQuanViewModels { get; set; }
    }
}
