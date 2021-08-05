using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class ChiTiet_HoaDon
    {
        public int ID { get; set; }
        public int ID_HoaDon { get; set; }
        public int ID_DichVu { get; set; }
        public HoaDon HoaDon { get; set; }
        public DichVu DichVu { get; set; }
        public int soLuongDichVu { get; set; }
        public string ghiChu { get; set; }
        public string trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
    }
}
