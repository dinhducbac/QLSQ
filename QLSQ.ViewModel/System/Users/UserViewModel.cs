using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.System.Users
{
    public class UserViewModel
    {
        public Guid ID { get; set; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
    }
}
