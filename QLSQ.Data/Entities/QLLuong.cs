using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace QL_SiQuan.Data.Entities
{
    public class QLLuong
    {
        public int IDLuong { set; get; }
        public int IDSQ { set; get; }
        public float HeSoLuong { set; get; }
        public ulong  LuongCoBan { set; get; }
        public float HeSoPhuCap { set; get; }

        public SiQuan SiQuan { set; get; }
    }
}
