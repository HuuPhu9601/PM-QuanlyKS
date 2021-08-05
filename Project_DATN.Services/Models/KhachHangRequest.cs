using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project_DATN.Services.Models
{
    public class KhachHangRequest
    {
        public int ID { get; set; }
        [Display(Name ="Mã Khách Hàng")]
        public string maKH { get; set; }
        [Display(Name = "Họ Tên Khách Hàng")]
        public string hoTenKH { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Giới Tính")]
        public string gioiTinh { get; set; }
        [Display(Name = "Số Điện Thoại")]
        public string soDienThoai { get; set; }
        [Display(Name = "CCCD/CMND")]
        public string CCCD { get; set; }
        [Display(Name = "Địa Chỉ")]
        public string diaChi { get; set; }
        [Display(Name = "Quốc Tịch")]
        public string quocTich { get; set; }
    }
}
