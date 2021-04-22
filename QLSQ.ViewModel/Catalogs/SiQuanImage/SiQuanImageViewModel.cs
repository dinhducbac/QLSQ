using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.SiQuanImage
{
    public class SiQuanImageViewModel
    {
        [Display(Name ="ID ảnh sĩ quan")]
        public int IDImage { get; set; }
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }
        [Display(Name = "Họ tên sĩ quan")]
        public string HoTenSQ { get; set; }
        [Display(Name = "Đường dẫn ảnh")]
        public string ImagePath { get; set; }
        [Display(Name = "Tiêu đề ảnh")]
        public string Caption { get; set; }
        [Display(Name = "Mặc định")]
        public bool IsDefault { get; set; }
        [Display(Name = "Ngày tạo ảnh")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Kích cỡ ảnh")]
        public long FileSize { get; set; }
    }
}
