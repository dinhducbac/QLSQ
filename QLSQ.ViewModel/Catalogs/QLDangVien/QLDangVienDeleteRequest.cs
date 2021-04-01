using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLDangVien
{
    public class QLDangVienDeleteRequest
    {
        public int IDQLDV { get; set; }
        public int IDSQ { get; set; }
        public string HoTen { get; set; }
        public DateTime NgayVaoDang { get; set; }
        public string NoiVaoDang { get; set; }
    }
}
