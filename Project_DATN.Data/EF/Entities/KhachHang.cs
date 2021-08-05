using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class KhachHang
    {
        public int ID { get; set; }
        public string maKH { get; set; }
        public string hoTenKH { get; set; }
        //Email có thể sẽ không có vì khách thuê hướng tới sự nhanh gọn
        public string email { get; set; }
        public string gioiTinh { get; set; }
        public string soDienThoai { get; set; }
        public string CCCD { get; set; }
        public string diaChi { get; set; }
        public string quocTich { get; set; }
        public string trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<DatPhong> ICDatPhong { get; set; }
        public ICollection<HoaDon> ICHoaDon { get; set; }

    }
}
