using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.Models
{
    public class CosoRequestValidator : AbstractValidator<CosoRequest>
    {
        public CosoRequestValidator()
        {
            //Không được để trống
            //RuleFor(x => x.email).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            //RuleFor(x => x.tenCoSo).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            //RuleFor(x => x.hoTenNguoiDaiDien).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            //RuleFor(x => x.maSoThue).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            //RuleFor(x => x.kyhieuphong).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            //RuleFor(x => x.soDienThoai).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            //RuleFor(x => x.kyhieuphong).NotEmpty().WithMessage("Vui lòng điển ký hiệu phòng");
            //RuleFor(x => x.soDienThoai).Length(10,11).WithMessage("Số điện thoại phải có tối thiểu 10 chữ số");
            //RuleFor(x => x.solau).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            //RuleFor(x => x.trangThai).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            //RuleFor(x => x.email).EmailAddress().WithMessage("Email chưa đúng định dạng");
            //RuleFor(x => x.ghiChu).MaximumLength(200).WithMessage("Ghi chú không được quá 200 ký tự");
        }
    }
}
