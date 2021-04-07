using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.HeSoPhuCapTheoChucVu
{
    public class HeSoPhuCapTheoChucVuViewModel
    {
        [Display(Name ="ID hệ số phụ cấp")]
        public int IDHeSoPhuCapCV { get; set; }
        [Display(Name = "ID chức vụ")]
        public int IDCV { get; set; }
        [Display(Name = "Tên chức vụ")]
        public string TenCV { get; set; }
        [Display(Name = "Hệ số phụ cấp")]
        public float HeSoPhuCap { get; set; }
    }
}
