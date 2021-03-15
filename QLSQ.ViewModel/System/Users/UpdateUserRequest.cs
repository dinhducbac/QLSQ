using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;

namespace QLSQ.ViewModel.System.Users
{
    public class UpdateUserRequest
    {
        public Guid  ID { get; set; }
        public string Email { get; set; }
        [Display(Name ="Số điện thoại")]
        public string PhoneNumber { get; set; }
        public string  Password { get; set; }
        [Display(Name ="Xác nhận mật khẩu")]
        public string PasswordConfirm { get; set; }
        
    }
}
