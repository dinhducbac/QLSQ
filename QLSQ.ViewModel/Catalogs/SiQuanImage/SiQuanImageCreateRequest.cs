using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.SiQuanImage
{
    public class SiQuanImageCreateRequest
    {
        [Display(Name = "Họ tên sĩ quan")]
        public string HoTenSQ { get; set; }
        [Display(Name = "ID sĩ quan")]
        public int IDSQ { get; set; }     
        [Display(Name = "Tiêu đề ảnh")]
        public string Caption { get; set; }
        [Display(Name = "Mặc định")]
        public bool IsDefault { get; set; }
 
        public IFormFile ImageFile { get; set; }

    }
}
