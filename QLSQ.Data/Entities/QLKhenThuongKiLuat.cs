using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class QLKhenThuongKiLuat
    {
        public int IDQLKTKL { get; set; }
        public int IDSQ { get; set; }
        public DateTime NgayThucHien { get; set; }
        
        public int LoaiKTKL { get; set; } // Khen thưởng hay kỉ  luật
        public string HinhThuc { get; set; } // Hình thức: huân huy chương, khiển trách
        public string DonViCap { get; set; } // đơn vị napf thực hiên quyết định
        public string NoiDung { get; set; }
        public SiQuan SiQuan { get; set; }

    }
}
