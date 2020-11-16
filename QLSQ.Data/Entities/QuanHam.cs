using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QL_SiQuan.Data.Entities
{

    public class QuanHam
    {
        public int IDQH { set; get; }
        public string TenQH { set; get; }

        public List<QLChucVu> QLChucVus { set; get; }
    }
}
