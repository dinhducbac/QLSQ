using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLCongTac
{
    public class QLCongTacDeleteRequest
    {
        public int IDCT { get; set; }
        public int IDSQ { get; set; }
        public string HoTen { get; set; }
        public string DiaChiCT { get; set; }
        public DateTime ThoiGianBatDauCT { get; set; }
        public DateTime ThoiGianKetThucCT { get; set; }
    }
}
