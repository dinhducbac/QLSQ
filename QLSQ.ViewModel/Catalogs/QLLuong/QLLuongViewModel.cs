using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLLuong
{
    public class QLLuongViewModel
    {
        public int IDLuong { get; set; }
        public int IDSQ { get; set; }
        public string HoTen { get; set; }
        public float HeSoLuong { get; set; }
        public float HeSoPhuCap { get; set; }
        public ulong LuongCB { get; set; }
        public ulong Luong { get; set; }
    }
}
