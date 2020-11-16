using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QL_SiQuan.Data.Entities
{
    public class QLNghiPhep
    {
        public int IDNP { set; get; }
        public int IDSQ { set; get; }
        public DateTime ThoiGianBDNP { set; get; }
        public int ThoiGianNP { set; get; }

        public SiQuan SiQuan { set; get; }
    }
}
