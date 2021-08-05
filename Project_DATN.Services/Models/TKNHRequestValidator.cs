using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.Models
{
    public class TKNHRequestValidator : AbstractValidator<TaiKhoanNganHangRequest>
    {
        public TKNHRequestValidator()
        {
            RuleFor(x => x.soTaiKhoan).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.soTaiKhoan).MaximumLength(13).WithMessage("Số tài khoản không đúng");
            RuleFor(x => x.diaChiCN).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.hoTenChuTKNH).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.tenChiNhanh).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.tenNganHang).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.trangThai).NotEmpty().WithMessage("Vui lòng điển đầy đủ thông tin");
            RuleFor(x => x.ghiChu).MaximumLength(200).WithMessage("Ghi chú không quá 200 ký tự");
        }
    }
}
