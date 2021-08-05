using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class Lau
    {
        public int ID { get; set; }
        public int ID_CoSo { get; set; }
        public CoSo CoSo { get; set; }
        //Tên lầu: Lầu 1, lầu 2... (lầu/ tầng)
        public string tenLau { get; set; }
        public int soLuongLau { get; set; }
        public string ghiChu { get; set; }
        public string trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<Phong> ICPhong { get; set; }
    }
}
