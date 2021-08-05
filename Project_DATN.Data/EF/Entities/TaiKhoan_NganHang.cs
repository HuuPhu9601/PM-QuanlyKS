using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class TaiKhoan_NganHang
    {
        public int ID { get; set; }
        public string hoTenChuTKNH { get; set; }
        public string soTaiKhoan { get; set; }
        public string tenNganHang { get; set; }
        public string tenChiNhanh { get; set; }
        //Địa chỉ chi nhánh ghi đầy đủ, rõ ràng chi tiết nhất: Ví dụ Số 88 Quan Hoa, Nguyễn Khánh Toàn, Cầu Giấy, Hà Nội
        public string diaChiCN { get; set; }
        public string ghiChu { get; set; }
        public string trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<CoSo> ICCoSo { get; set; }

    }
}
