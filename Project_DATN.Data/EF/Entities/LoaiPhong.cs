using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class LoaiPhong
    {
        public int ID { get; set; }
        public string tenLoaiPhong { get; set; }
        public decimal donGiaTheoGio { get; set; }
        public decimal donGiaTheoNgay { get; set; }
        public decimal donGiaQuaDem { get; set; }
        public int soNguoi { get; set; }
        public string ghiChu { get; set; }
        public string trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<Phong> ICPhong { get; set; }
        public ICollection<HoaDon> ICHoaDon { get; set; }
        public ICollection<DatPhong> ICDatPhong { get; set; }
    }
}
