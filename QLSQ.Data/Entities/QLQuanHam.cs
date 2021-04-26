using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class QLQuanHam
    {
        public int IDQLQH { get; set; }
        public int IDSQ { get; set; }
        public int IDQH { get; set; }
        public int IDHeSoLuongTheoQH { get; set; }
        public HeSoLuongTheoQuanHam HeSoLuongTheoQuanHam { get; set; }
        public SiQuan SiQuan { get; set; }
        public QuanHam QuanHam { get; set; }
        public List<QLLuong> QLLuongs { get; set; }
    }
}
