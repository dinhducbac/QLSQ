
using Microsoft.AspNetCore.Http;
using QLSQ.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.SiQuan
{
    public class SiQuanCreateRequest
    {
        [Display(Name = "ID tài khoản")]
        public Guid UserId { get; set; }
        [Display(Name = "Họ và tên")]
        public string HoTen { get; set; }
        [Display(Name = "Ngày tháng năm sinh")]
        public DateTime NgaySinh { get; set; }
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }
        [Display(Name = "Quê quán")]
        public string QueQuan { get; set; }
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public IFormFile ThumbnailImage { get; set; }

        public List<UserViewModel> userViewModels { get; set; }

    }
}
