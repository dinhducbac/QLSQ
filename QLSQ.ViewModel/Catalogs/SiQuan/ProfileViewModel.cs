using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.SiQuan
{
    public class ProfileViewModel
    {
        public Guid UserID { get; set; }
        public int IDSQ { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string SDT { get; set; }
        public string ImagePath { get; set; }
    }
}
