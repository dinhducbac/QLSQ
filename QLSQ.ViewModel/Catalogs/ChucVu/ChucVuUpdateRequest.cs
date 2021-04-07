using QLSQ.ViewModel.Catalogs.BoPhan;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.ChucVu
{
    public class ChucVuUpdateRequest
    {


        [Display(Name = "ID bộ phận")]
        public int IDBP { get; set; }
        [Display(Name = "ID chức vụ")]
        public int IDCV { get; set; }
        [Display(Name = "Tên chức vụ")]
        public string TenCV { get; set; }
        public List<BoPhanViewModel> boPhanViewModels { get; set; }
    }
}
