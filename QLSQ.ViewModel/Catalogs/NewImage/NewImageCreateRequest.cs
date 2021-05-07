using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.NewImage
{
    public class NewImageCreateRequest
    {
        [Display(Name = "Tiêu đề tin tức")]
        public string NewName { get; set; }
        [Display(Name = "ID tin tức")]
        public int NewID { get; set; }
        [Display(Name = "Đường dẫn ảnh tin tức")]
        public string ImagePath { get; set; }
        [Display(Name = "Ngày tạo ảnh tin tức")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Kích cỡ ảnh tin tức")]
        public long FileSize { get; set; }
        [Display(Name ="Tải tệp ảnh")]
        public IFormFile FormFile { get; set; }
    }
}
