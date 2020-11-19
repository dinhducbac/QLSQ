using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class BoPhan
    {
        public int IDBP { set; get; }
        public string TenBP { set; get; }

        public List<ChucVu> ChucVus { set; get; }
    }
}
