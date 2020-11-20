using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class ChucVu
    {
        public int IDCV { get; set; }
        public string TenCV { get; set; }
        public int IDBP { get; set; }

        public BoPhan BoPhan { get; set; }
        public List<QLChucVu> QLChucVus { get; set; }
    }
}
