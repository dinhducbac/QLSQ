using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class QLNghiPhep
    {
        public int IDNP { set; get; }
        public int IDSQ { set; get; }
        public DateTime ThoiGianBDNP { set; get; }
        public DateTime ThoiGianKTNP { set; get; }
        public int NghiPhepState { get; set; }
        public SiQuan SiQuan { set; get; }
    }
}
