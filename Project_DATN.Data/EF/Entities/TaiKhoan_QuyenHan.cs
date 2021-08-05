using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class TaiKhoan_QuyenHan
    {
        public int ID { get; set; }
        public int ID_QuyenHan { get; set; }
        public int ID_TaiKhoan { get; set; }
        public QuyenHan QuyenHan { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        //mã sử dụng để dùng ƯD: tương tự Licensed
        public string maSuDung { get; set; }
        public string moTa { get; set; }
        public string trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
    }
}
