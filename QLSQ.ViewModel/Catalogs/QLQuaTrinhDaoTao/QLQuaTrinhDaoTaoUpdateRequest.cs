using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLQuaTrinhDaoTao
{
    public class QLQuaTrinhDaoTaoUpdateRequest
    {
        [Display(Name = "ID quá trình đào tạo")]
        public int IDQLQTDT { get; set; }
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name = "Họ tên sĩ quan")]
        public string HoTen { get; set; }
        [Display(Name = "Tên trường đào tạo")]
        public string TenTruong { get; set; }
        [Display(Name = "Ngành học đào tạo")]
        public string NganhHoc { get; set; }
        [Display(Name = "Thời gian bắt đầu đào tạo")]
        public DateTime ThoiGianBDDT { get; set; }
        [Display(Name = "Thời gian kết thúc đào tạo")]
        public DateTime ThoiGianKTDT { get; set; }
        [Display(Name = "Hình thức đào tạo")]
        public string HinhThucDT { get; set; }
        [Display(Name = "Văn bằng đào tạo")]
        public string VanBang { get; set; }
    }
}
