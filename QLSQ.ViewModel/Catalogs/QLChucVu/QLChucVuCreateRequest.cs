using QLSQ.ViewModel.Catalogs.BoPhan;
using QLSQ.ViewModel.Catalogs.ChucVu;
using QLSQ.ViewModel.Catalogs.QuanHam;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLChucVu
{
    public class QLChucVuCreateRequest
    {
        public int IDSQ { get; set; }
        public int IDQH { get; set; }
        public int IDBP { get; set; }
        public int IDCV { get; set; }


        public List<QuanHamViewModel> quanHamViewModels { get; set; }
        public List<BoPhanViewModel> boPhanViewModels { get; set; }
        public List<ChucVuViewModel> chucVuViewModels { get; set; }
    }
}
