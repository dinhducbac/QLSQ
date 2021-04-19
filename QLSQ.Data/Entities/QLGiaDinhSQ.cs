using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class QLGiaDinhSQ
    {
        public int IDQLGDSQ { get; set; }
        public int IDSQ { get; set; }
        public string QuanHe { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GhiChu { get; set; }
        public SiQuan SiQuan { get; set; }
    }
}
