using QLSQ.ViewModel.Catalogs.BoPhan;
using QLSQ.ViewModel.Catalogs.ChucVu;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.HeSoPhuCapTheoChucVu
{
    public class HeSoPhuCapTheoChucVuCreateRequest
    {
        public int IDBP { get; set; }
        public int IDCV { get; set; }
        public float HeSoPhuCap { get; set; }
        public List<BoPhanViewModel> boPhanViewModels { get; set; }
        public List<ChucVuViewModel> chucVuViewModels { get; set; }

    }
}
