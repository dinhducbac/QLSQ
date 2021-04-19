using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class QLQuaTrinhDaoTao
    {
        public int IDQLQTDT { get; set; }
        public int IDSQ { get; set; }
        public string TenTruong { get; set; }
        public string NganhHoc { get; set; }
        public DateTime ThoiGianBDDT { get; set; }
        public DateTime ThoiGianKTDT { get; set; }
        public string HinhThucDT { get; set; }
        public string VanBang { get; set; }
        public SiQuan SiQuan { get; set; }

    }
}
