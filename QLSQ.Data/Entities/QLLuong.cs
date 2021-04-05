using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class QLLuong
    {
        public int IDLuong { set; get; }
        public int IDSQ { set; get; }
        public int IDHeSoLuongQH { set; get; }
        public int IDLuongCB { set; get; }
        public int IDHeSoPhuCapCV { set; get; }

        public SiQuan SiQuan { set; get; }
        public HeSoLuongTheoQuanHam HeSoLuongTheoQuanHam { get; set; }
        public HeSoPhuCapTheoChucVu HeSoPhuCapTheoChucVu { get; set; }
        public LuongCoBan LuongCoBan { get; set; }
    }
}
