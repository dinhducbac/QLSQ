using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class QLCongTac
    {
        public int IDCT { set; get; }
        public int IDSQ { set; get; }
        public string DiaChiCT { set; get; }
        public DateTime ThoiGianBatDauCT { set; get; }
        public DateTime ThoiGianKetThucCT { get; set; }

        public SiQuan SiQuan { set; get; }



    }
}
