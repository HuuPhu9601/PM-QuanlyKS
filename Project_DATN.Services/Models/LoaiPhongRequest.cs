using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DATN.Services.Models
{
    public class LoaiPhongRequest
    {
        public int Id { get; set; }
        public string tenLoaiPhong { get; set; }
        public decimal donGiaTheoGio { get; set; }
        public decimal donGiaTheoNgay { get; set; }
        public decimal donGiaQuaDem { get; set; }
        public int soNguoi { get; set; }
        public string ghiChu { get; set; }
        public string trangThai { get; set; }
        public string fields1 { get; set; }
    }
}
