using QLSQ.ViewModel.Catalogs.SiQuan;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLCongTac
{
    public class QLCongTacCreateRequest
    {
        public int IDSQ { get; set; }
        public string DiaChiCT { get; set; }
        public DateTime ThoiGianBatDauCT { get; set; }
        public DateTime ThoiGianKetThucCT { get; set; }
        public List<SiQuanViewModel> siQuanViewModels { get; set; }

    }
}
