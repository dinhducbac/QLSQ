using QLSQ.ViewModel.Catalogs.BoPhan;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.ChucVu
{
    public class ChucVuCreateRequest
    {
        public int IDBP { get; set; }
        public string TenCV { get; set; }
        public List<BoPhanViewModel> boPhanViewModels { get; set; }
    }
}
