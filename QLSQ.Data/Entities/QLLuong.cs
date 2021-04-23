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
        public int IDQLQH { get; set; }
        public int IDQLCV { get; set; }
        public int IDLuongCB { get; set; }

        public SiQuan SiQuan { set; get; }
        public QLQuanHam QLQuanHam { get; set; }
        public QLChucVu QLChucVu { get; set; }
        public LuongCoBan LuongCoBan { get; set; }
    }
}
