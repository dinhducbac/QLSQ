using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.System.Users
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.PhoneNumber).MinimumLength(10).WithMessage("Số điện thoại phải là 10 chữ số").MaximumLength(10)
                .WithMessage("Số điện thoại phải là 10 chữ số");
            RuleFor(x => x.PhoneNumber).SetValidator(new RegularExpressionValidator(@"^[0-9]"))
                .WithMessage("Số điện thoại chỉ là số!");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Mật khâu tối thiểu có 6 chữ số");
            RuleFor(x => x.Password).SetValidator(new RegularExpressionValidator(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]"))
                .WithMessage("Mật khẩu phải có ít nhất 1 chữ hoa, 1 chữ thường, 1 chữ số, 1 kí tự đặc biệt");
            RuleFor(x => x.PasswordConfirm).MinimumLength(6).WithMessage("Mật khâu tối thiểu có 6 chữ số");
            RuleFor(x => x.PasswordConfirm).SetValidator(new RegularExpressionValidator(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]"))
                .WithMessage("Mật khẩu phải có ít nhất 1 chữ hoa, 1 chữ thường, 1 chữ số, 1 kí tự đặc biệt");
        }
    }
}
