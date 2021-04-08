using QLSQ.ViewModel.Catalogs.BoPhan;
using QLSQ.ViewModel.Catalogs.ChucVu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.HeSoPhuCapTheoChucVu
{
    public class HeSoPhuCapTheoChucVuUpdateRequest
    {
        [Display(Name = "ID hệ số phụ cấp")]
        public int IDHeSoPhuCapCV { get; set; }
        [Display(Name = "ID bộ phận")]
        public int IDBP { get; set; }
        [Display(Name = "ID chức vụ")]
        public int IDCV { get; set; }
        [Display(Name = "Hệ số phụ cấp")]
        public float HeSoPhuCap { get; set; }
        public List<BoPhanViewModel> boPhanViewModels { get; set; }
        public List<ChucVuViewModel> chucVuViewModels { get; set; }
    }
}
