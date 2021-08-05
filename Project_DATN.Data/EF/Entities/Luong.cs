using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class Luong
    {
        public int ID { get; set; }

        public int ID_TaiKhoan { get; set; }
        public TaiKhoan TaiKhoan { get; set; }

        public DateTime ngayBatDauApDung { get; set; }
        // Ngày kết thúc áp dụng (tăng lương/ giảm lương) trường này sẽ được sửa khi có quyết định mới
        public DateTime? denNgay { get; set; }
        //public decimal mucLuongCoBan { get; set; }
        //public decimal tienThuong { get; set; }
        //public decimal tienPhat { get; set; }
        //public decimal tienLamThem { get; set; }
        //public decimal tienBHXH { get; set; }
        //public decimal tienBHYT { get; set; }
        //public decimal tienThatNghiep { get; set; }
        //public decimal kinhPhiCongDoan { get; set; }
        public decimal tienThucLinh { get; set; }
        //Đơn vị tính tiền: VNĐ
        public string donViTinhTien { get; set; }
        public string ghiChu { get; set; }
        public string trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
    }
}
