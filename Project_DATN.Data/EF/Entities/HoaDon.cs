using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class HoaDon
    {
        public int ID { get; set; }
        public int ID_KhachHang { get; set; }
        public int ID_TaiKhoan { get; set; }
        public int ID_GiaoDich { get; set; }
        public int ID_LoaiPhong { get; set; }
        public int ID_Phong { get; set; }
        public int ID_GiaoCa { get; set; }
        public KhachHang KhachHang { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public GiaoDich GiaoDich { get; set; }
        public Phong Phong { get; set; }
        public GiaoCa GiaoCa { get; set; }
        public LoaiPhong LoaiPhong { get; set; }
        //Mã hoá đơn là tên gọi của hoá đơn: HD0001 ...
        public string maHoaDon { get; set; }
        [Display(Name = "Invoicing time ")]
        public DateTime ngayGioLap { get; set; }
        [Display(Name = "Check in")]
        public DateTime ngayGioNhanPhong { get; set; }
        [Display(Name = "Check out")]

        public DateTime ngayGioTraPhong { get; set; }
        [Display(Name = "Check out-date")]
        //Hiển thị thời gian thuê phòng
        public string thoiGianThue { get; set; }
        [Display(Name = "Money given")]
        [Required(ErrorMessage = "Trường Này Không Được Bỏ Trống")]
        public decimal tienKhachDua { get; set; }
        [Display(Name = "Refunds")]
        public decimal tienTraLai { get; set; }
        [Display(Name = "Turret reduction ")]
        public decimal giamTru { get; set; }
        [Display(Name = "Deposit money  ")]
        public decimal cocTien { get; set; }
        [Display(Name = "surcharge   ")]
        public decimal phuThu { get; set; }
        [Display(Name = "Tax VAT   ")]
        public decimal thueVAT { get; set; }
        [Display(Name = "Discount   ")]
        public decimal chietKhau { get; set; }
        [Display(Name = "Sale   ")]
        public decimal giamGia { get; set; }
        [Display(Name = "Note   ")]
        public string ghiChu { get; set; }
        //Trạng thái đã thanh toán/ chưa thanh toán...
        [Display(Name = "Status   ")]
        public string trangThai { get; set; }
        //Không cho nợ tiền
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<ChiTiet_HoaDon> ICChiTiet_HoaDon { get; set; }

    }
}
