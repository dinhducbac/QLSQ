using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.SiQuan
{
    public class SiQuanUpdateRequest
    {
        [Display(Name ="ID")]
        public int IDSQ { get; set; }
        [Display(Name ="ID tài khoản")]
        public Guid UserId { get; set; }
        [Display(Name ="Họ và tên")]
        public string HoTen { get; set; }
        [Display(Name = "Ngày tháng năm sinh")]
        public DateTime NgaySinh { get; set; }
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }
        [Display(Name = "Quê quán")]
        public string QueQuan { get; set; }
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }
        public IFormFile ThumbnailImage { get; set; }

    }
}
