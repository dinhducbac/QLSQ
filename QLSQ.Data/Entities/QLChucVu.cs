﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QLSQ.Data.Entities
{
    public class QLChucVu
    {
        public int IDQLCV { set; get; }
        public int IDSQ { set; get; }
        public int IDCV { set; get; }
        public DateTime NgayNhan { get; set; }
        public SiQuan SiQuan { set; get; }
        public ChucVu ChucVu { set; get; }
        public List<QLLuong> QLLuongs { get; set; }
    }
}
