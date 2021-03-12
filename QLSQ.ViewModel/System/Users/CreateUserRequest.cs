using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.System.Users
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public string PasswordConfirm { set; get; }
    }
}
