using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class Phong
    {
        public int ID { get; set; }
        public int ID_LoaiPhong { get; set; }
        public int ID_CoSo { get; set; }
        public int ID_Lau { get; set; }
        public LoaiPhong LoaiPhong { get; set; }
        public CoSo CoSo { get; set; }
        public Lau Lau { get; set; }
        //Tên phòng: Pxx1 (P01, P001...)...
        //Hoặc Phòng 1 ....
        public string tenPhong { get; set; }
        public int soLuongPhong { get; set; }

        public string ghiChu { get; set; }
        public string trangThai { get; set; }

        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<HoaDon> ICHoaDon { get; set; }
    }
}
