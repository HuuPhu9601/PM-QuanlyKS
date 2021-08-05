using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.Models
{
    class PhongRequestValidator : AbstractValidator<PhongRequest>
    {
        public PhongRequestValidator()
        {
            RuleFor(x => x.tenPhong).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.ID_Lau).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.ID_LoaiPhong).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.ID_CoSo).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.trangThai).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
        }
    }
}
