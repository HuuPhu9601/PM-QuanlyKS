using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.Models
{
    public class ChiTietHoaDonRequest
    {
        public int ID { get; set; }
        public int ID_HoaDon { get; set; }
        public int ID_DichVu { get; set; }
        public int soLuongDichVu { get; set; }
        public string ghiChu { get; set; }
        public string trangThai { get; set; }
    }
}
