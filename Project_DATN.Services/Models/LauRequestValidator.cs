using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.Models
{
    public class LauRequestValidator : AbstractValidator<LauRequest>
    {
        public LauRequestValidator()
        {
            RuleFor(x => x.tencoso).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.tenLau).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.soLuongLau).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.trangThai).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.ID_CoSo).NotNull().WithMessage("Vui lòng chọn cơ sở");
            RuleFor(x => x.SoLuongPhong).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
        }
    }
}
