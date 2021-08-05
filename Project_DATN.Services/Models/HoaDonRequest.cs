using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.Models
{
    public class HoaDonRequest
    {
        public int ID { get; set; }
        public int ID_KhachHang { get; set; }
        public int ID_TaiKhoan { get; set; }
        public int ID_GiaoDich { get; set; }
        public int ID_LoaiPhong { get; set; }
        public int ID_Phong { get; set; }
        public int ID_GiaoCa { get; set; }
        public string maHoaDon { get; set; }
       
        public DateTime ngayGioLap { get; set; }
        public DateTime ngayGioNhanPhong { get; set; }

        public DateTime ngayGioTraPhong { get; set; }
        public string thoiGianThue { get; set; }
        public decimal tienKhachDua { get; set; }
        public decimal tienTraLai { get; set; }
        public decimal giamTru { get; set; }
        public decimal cocTien { get; set; }
        public decimal phuThu { get; set; }
        public decimal thueVAT { get; set; }
        public decimal chietKhau { get; set; }
        public decimal giamGia { get; set; }
        public string ghiChu { get; set; }
        public string trangThai { get; set; }
    }
}
