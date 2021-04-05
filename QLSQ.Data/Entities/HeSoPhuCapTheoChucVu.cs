using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class HeSoPhuCapTheoChucVu
    {
        public int IDHeSoPhuCapCV { get; set; }
        public int IDCV { get; set; }
        public float HeSoPhuCap { get; set; }
        public ChucVu ChucVu { get; set; }
        public List<QLLuong> QLLuongs { get; set; }
    }
}
