using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class LuongCoBan
    {
        public int IDLuongCB { get; set; }
        public ulong LuongCB { get; set; }
        public List<QLLuong> QLLuongs { get; set; }
    }
}
