﻿using Microsoft.AspNetCore.Http;
using QLSQ.ViewModel.Catalogs.NewCatetory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.New
{
    public class NewUpdateRequest 
    {
        [Display(Name = "ID tin tức")]
        public int NewID { get; set; }
        [Display(Name = "Loại tin tức")]
        public int NewCatetoryID { get; set; }
        [Display(Name = "Tiêu đề tin tức")]
        public string NewName { get; set; }
        [Display(Name = "Đường dẫn ảnh")]
        public string ImagePath { get; set; }
        [Display(Name = "Nội dung")]
        public string NewContent { get; set; }
        [Display(Name = "Ngày đăng tin tức")]
        public DateTime NewDatePost { get; set; }
        [Display(Name = "Lượt xem tin tức")]
        public int NewCount { get; set; }
        public IFormFile FormFile { get; set; }

        public List<NewCatetoryViewModel> NewCatetoryViewModels { get; set; }

    }
}
