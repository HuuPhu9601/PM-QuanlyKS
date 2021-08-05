using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.Models
{
    public class LoaiPhongRequestValidator : AbstractValidator<LoaiPhongRequest>
    {
        public LoaiPhongRequestValidator()
        {
            RuleFor(x => x.tenLoaiPhong).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.soNguoi).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.trangThai).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.ghiChu).MaximumLength(200).WithMessage("Ghi chú không quá 200 ký tự");
        }
    }
}
