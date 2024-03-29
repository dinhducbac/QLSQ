﻿using QLSQ.ViewModel.Catalogs.SiQuan;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLCongTac
{
    public class QLCongTacCreateRequest
    {
        [Display(Name ="Họ tên sĩ quan")]
        public string HoTen { get; set; }
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name = "Địa chỉ công tác")]
        public string DiaChiCT { get; set; }
        [Display(Name = "Thời gian bắt đầu công tác")]
        public DateTime ThoiGianBatDauCT { get; set; }
        [Display(Name = "Thời gian kết thúc công tác")]
        public DateTime ThoiGianKetThucCT { get; set; }
        [Display(Name = "Trạng thái công tác")]
        public int CongTacState { get; set; }

    }
}
