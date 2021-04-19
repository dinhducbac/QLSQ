using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalog.QLKhenThuongKiLuat
{
    public class QLKhenThuongKiLuatViewModel
    {
        public int IDKTKL { get; set; }
        public int IDSQ { get; set;}
        public string HoTen { get; set; }
        public DateTime NgayThucHien { get; set; }
        public int LoaiKTKL { get; set; }
        public string HinhThuc { get; set; }
        public string DonViCap { get; set; }
        public string NoiDung { get; set; }
    }
}
