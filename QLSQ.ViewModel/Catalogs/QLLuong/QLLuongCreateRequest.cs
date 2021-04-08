using QLSQ.ViewModel.Catalogs.SiQuan;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLLuong
{
    public class QLLuongCreateRequest
    {
        public int IDSQ { get; set; }
        public int IDHeSoLuongQH { get; set; }
        public int IDLuongCB { get; set; }
        public int IDHeSoPhuCapCV { get; set; }
        public List<SiQuanViewModel> siQuanViewModels { get; set; }
    }
}
