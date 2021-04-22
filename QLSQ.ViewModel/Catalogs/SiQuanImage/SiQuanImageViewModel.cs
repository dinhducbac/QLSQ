using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.SiQuanImage
{
    public class SiQuanImageViewModel
    {
        public int IDImage { get; set; }
        public int IDSQ { get; set; }
        public string HoTenSQ { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime DateCreated { get; set; }
        public long FileSize { get; set; }
    }
}
