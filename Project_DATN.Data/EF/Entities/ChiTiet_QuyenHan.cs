using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class ChiTiet_QuyenHan
    {
        public int ID { get; set; }
        public int ID_QuyenHan { get; set; }
        public QuyenHan QuyenHan { get; set; }
        //mã hành động: ví dụ định nghĩa mã là Edit thì sẽ có quyền sửa, Read: Chỉ có quyền xem...
        public string maHanhDong { get; set; }
        //Kiểm tra hành động thực hiện có thành công/ chưa thành công
        public string kiemTraHanhDong { get; set; }
        public string moTa { get; set; }
        public string trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
    }
}
