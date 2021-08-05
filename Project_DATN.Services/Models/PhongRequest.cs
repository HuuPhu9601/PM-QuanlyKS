using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DATN.Services.Models
{
    public class PhongRequest
    {
        public int Id { get; set; }
        public int ID_LoaiPhong { get; set; }
        public int ID_CoSo { get; set; }
        public int ID_Lau { get; set; }
        //Tên phòng: Pxx1 (P01, P001...)...
        //Hoặc Phòng 1 ....
        public string tenPhong { get; set; }

        public string ghiChu { get; set; }
        public string trangThai { get; set; }
        public LoaiPhong LoaiPhong { get; set; }
        public CoSo CoSo { get; set; }
        public Lau Lau { get; set; }
    }
}
