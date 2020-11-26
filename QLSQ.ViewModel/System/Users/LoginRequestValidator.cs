using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace QLSQ.ViewModel.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bạn phải nhập Username");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Bạn phải nhập Password")
                .MinimumLength(6).WithMessage("Mật khẩu phải trên 6 kí tự");
        }
    }
}
