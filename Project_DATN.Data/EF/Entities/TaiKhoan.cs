using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Project_DATN.Data.EF.Entities.Enums;

namespace Project_DATN.Data.EF.Entities
{
    public class TaiKhoan
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings= false,ErrorMessage = "Vui lòng chọn một cơ sở")]
        public int ID_CoSo { get; set; }
        [Required(AllowEmptyStrings= false,ErrorMessage = "Vui lòng chọn một phòng ban")]
        public int ID_PhongBan { get; set; }
        
        [Required(AllowEmptyStrings= false,ErrorMessage = "Mời nhập tên tài khoản")]
        [Display(Name = "Tên tài khoản")]
        [StringLength(32,MinimumLength = 5,ErrorMessage = "Tên tài khoản phải có độ dài 5 - 32 ký tự")]
        public string tenTaiKhoan { get; set; }
        [Required(AllowEmptyStrings= false,ErrorMessage = "Mời nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [StringLength(32,MinimumLength = 6,ErrorMessage = "Mật khẩu phải có độ dài 6-32 ký tự")]
        public string matKhau { get; set; }
        [Required(AllowEmptyStrings= false,ErrorMessage = "Mời nhập tên chủ TK")]
        [Display(Name = "Họ tên chủ TK")]
        public string hoTenChuTK { get; set; }
        [Required(AllowEmptyStrings= false,ErrorMessage = "Mời nhập email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Địa chỉ Email không hợp lệ" )]
        public string email { get; set; }
        [Required(AllowEmptyStrings= false,ErrorMessage = "Vui lòng chọn ngày sinh")]
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime ngayThangNamSinh { get; set; }
        //Giới tính: Nam, Nữ, Giới tính thứ 3, 4...
        [Display(Name = "Giới tính")]
        public GioiTinh gioiTinh { get; set; }
        [Required(AllowEmptyStrings= false,ErrorMessage = "Mời nhập số điện thoại")]
        [Display(Name = "SĐT")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Sai định dạng số điện thoại")]
        public string soDienThoai { get; set; }
        [Required(AllowEmptyStrings= false,ErrorMessage = "Mời nhập số CCCD")]
        [Display(Name = "CCCD")]
        public string CCCD { get; set; }
        [Required(AllowEmptyStrings= false,ErrorMessage = "Mời nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        public string diaChi { get; set; }
        [Required(ErrorMessage = "Nhập ngày vào làm")]
        [Display(Name = "Ngày vào làm")]
        [DataType(DataType.Date)]
        public DateTime ngayVaoLam { get; set; }
        [Display(Name = "Ngày kết thúc hợp đồng")]
        [DataType(DataType.Date)]
        public DateTime? ngayKetThucHopDong { get; set; }
        [Required(AllowEmptyStrings= false,ErrorMessage = "Chọn trạng thái tài khoản")]
        [Display(Name = "Trạng thái")]
        public TrangThai TrangThai { get; set; }
        /*Trạng thái tài khoản
        *Hoạt động = Những người cần sử dụng hệ thống (Chủ/ Quản lý/ Lễ tân...)
        *Không hoạt động: Những người không cần sử dụng hệ thống (Lao công/ Bảo vệ...)
     */
        [Display(Name = "Ảnh đại diện")]
        public string anhDaiDien { get; set; }
        [NotMapped]
        [Display(Name = "Ảnh đại diện")]
        public IFormFile AvatarFile { get; set; }
        [Display(Name = "Cơ sở")]
        [JsonIgnore]
        public virtual CoSo CoSo { get; set; }
        [Display(Name = "Phòng ban")]
        [JsonIgnore]
        public virtual PhongBan PhongBan { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<HoaDon> ICHoaDon { get; set; }
        public ICollection<ChucVu> ICChucVu { get; set; }
        public ICollection<Luong> ICLuong { get; set; }
        public ICollection<TaiKhoan_QuyenHan> IC_TK_QH { get; set; }
        public ICollection<GiaoCa> ICGiaoCa { get; set; }
    }
}
