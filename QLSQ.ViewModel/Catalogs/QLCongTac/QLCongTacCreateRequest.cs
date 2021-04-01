using QLSQ.ViewModel.Catalogs.SiQuan;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.QLCongTac
{
    public class QLCongTacCreateRequest
    {
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name = "Địa chỉ công tác")]
        public string DiaChiCT { get; set; }
        [Display(Name = "Thời gian bắt đầu công tác")]
        public DateTime ThoiGianBatDauCT { get; set; }
        [Display(Name = "Thời gian kết thúc công tác")]
        public DateTime ThoiGianKetThucCT { get; set; }
        public List<SiQuanViewModel> siQuanViewModels { get; set; }

    }
}
