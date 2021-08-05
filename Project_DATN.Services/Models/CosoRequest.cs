using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DATN.Services.Models
{
    public class CosoRequest
    {
        public int Id { get; set; }
        public string tenCoSo { get; set; }
        public string hoTenNguoiDaiDien { get; set; }
        public string maSoThue { get; set; }
        public string soDienThoai { get; set; }
        public string email { get; set; }
        public string ghiChu { get; set; }

        public string trangThai { get; set; }
        public int ID_Tinh_TP { get; set; }
        public int ID_Quan_Huyen { get; set; }
        public int ID_TK_NH { get; set; }
        public string kyhieuphong { get; set; }
        public int solau { get; set; }
        public int idloaiphong { get; set; }
        public List<string> soluongphong { get; set; }
        public string Tinh_TP { get; set; }
        public string Sotaikhoan { get; set; }
        public string QuanHuyen { get; set; }
    }
}
