using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLKhenThuongKiLuat
{
    public class QLKhenThuongKiLuatDeleteRequest
    {
        [Display(Name = "ID Khen thưởng/kỉ luật")]
        public int IDQLKTKL { get; set; }
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name = "Họ tên sĩ quan")]
        public string HoTen { get; set; }
        [Display(Name = "Ngày thực hiện")]
        public DateTime NgayThucHien { get; set; }
        [Display(Name = "Loại")]
        public int LoaiKTKL { get; set; }
        [Display(Name = "Hình thức")]
        public string HinhThuc { get; set; }
        [Display(Name = "Đơn vị cấp")]
        public string DonViCap { get; set; }
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }
    }
}
