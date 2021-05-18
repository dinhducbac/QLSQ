using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLSQ.ViewModel.Catalogs.SiQuan
{
    public class SiQuanCreateRequestValidator : AbstractValidator<SiQuanCreateRequest>
    {
        public SiQuanCreateRequestValidator()
        {
            RuleFor(x => x.HoTen).SetValidator(new RegularExpressionValidator(@"^([A-z][A-Za-z]*\s*[A-Za-z]*)$"))
                .WithMessage("Họ tên không thể chứa chữ số");
            RuleFor(x => x.SDT).Matches("^[0-9]").WithMessage("Số điện thoại không thể chứa chữ cái");
            RuleFor(x => x.SDT).MinimumLength(10).WithMessage("Số điện thoại phải là 10 chữ số")
                .MaximumLength(10).WithMessage("Số điện thoại phải là 10 chữ số");
        }
    }
}
