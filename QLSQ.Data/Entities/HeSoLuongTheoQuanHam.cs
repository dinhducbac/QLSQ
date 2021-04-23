using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class HeSoLuongTheoQuanHam
    {
        public int IDHeSoLuongQH { get; set; }
        public int IDQH { get; set; }
        public string TenHeSoLuongQH { get; set; }
        public float HeSoLuong { get; set; }    
        public QuanHam QuanHam { get; set; }
        public List<QLQuanHam> QLQuanHams { get; set; }

    }
}
