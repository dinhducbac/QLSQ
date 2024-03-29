﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam
{
    public class HeSoLuongTheoQuanHamUpdateRequest
    {
        [Display(Name = "ID hệ số lương")]
        public int IDHeSoLuongQH { get; set; }
        [Display(Name = "ID quân hàm")]
        public int IDQH { get; set; }
        [Display(Name = "Tên quân hàm")]
        public string TenQH { get; set; }
        [Display(Name = "Tên hệ số lương quân hàm")]
        public string TenHeSoLuongQH { get; set; }
        [Display(Name = "Hệ số lương")]
        [DataType(DataType.Currency, ErrorMessage = "Hệ số lương phải là chữ số")]
        public float HeSoLuong { get; set; }
    }
}
