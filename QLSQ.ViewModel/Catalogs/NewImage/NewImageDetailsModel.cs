using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.NewImage
{
    public class NewImageDetailsModel
    {
        [Display(Name = "ID ảnh tin tức")]
        public int NewImageID { get; set; }
        [Display(Name = "ID tin tức")]
        public int NewID { get; set; }
        [Display(Name ="Tiêu đề tin tức")]
        public string NewName { get; set; }
        [Display(Name = "Đường dẫn ảnh tin tức")]
        public string ImagePath { get; set; }
        [Display(Name = "Ngày tạo ảnh tin tức")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Kích cỡ ảnh tin tức")]
        public long FileSize { get; set; }
    }
}
