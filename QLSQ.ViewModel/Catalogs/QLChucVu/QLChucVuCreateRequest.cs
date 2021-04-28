using QLSQ.ViewModel.Catalogs.BoPhan;
using QLSQ.ViewModel.Catalogs.ChucVu;
using QLSQ.ViewModel.Catalogs.QuanHam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLChucVu
{
    public class QLChucVuCreateRequest
    {
        [Display(Name ="ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name = "ID bộ phận")]
        public int IDBP { get; set; }
        [Display(Name = "ID chức vụ")]
        public int IDCV { get; set; }
        [Display(Name = "Ngày nhận")]
        public DateTime NgayNhan { get; set; }


        public List<QuanHamViewModel> quanHamViewModels { get; set; }
        public List<BoPhanViewModel> boPhanViewModels { get; set; }
        public List<ChucVuViewModel> chucVuViewModels { get; set; }
    }
}
