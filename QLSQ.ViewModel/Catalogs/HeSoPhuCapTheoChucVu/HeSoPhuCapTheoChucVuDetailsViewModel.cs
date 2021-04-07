using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.Application.Catalog.HeSoPhuCapTHeoChucVu
{
    public class HeSoPhuCapTheoChucVuDetailsViewModel
    {
        [Display(Name = "ID hệ số phụ cấp")]
        public int IDHeSoPhuCapCV { get; set; }
        [Display(Name = "ID bộ phận")]
        public int IDBP { get; set; }
        [Display(Name = "Tên bộ phận")]
        public string TenBP { get; set; }
        [Display(Name = "ID chức vụ")]
        public int IDCV { get; set; }
        [Display(Name = "Tên chức vụ")]
        public string TenCV { get; set; }
        [Display(Name = "Hệ số phụ cấp")]
        public float HeSoPhuCap { get; set; }
    }
}
