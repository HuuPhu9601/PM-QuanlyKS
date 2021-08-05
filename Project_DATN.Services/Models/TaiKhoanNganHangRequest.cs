using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DATN.Services.Models
{
    public class TaiKhoanNganHangRequest
    {
        public int Id { get; set; }
        public string hoTenChuTKNH { get; set; }
        public string soTaiKhoan { get; set; }
        public string tenNganHang { get; set; }
        public string tenChiNhanh { get; set; }
        //Địa chỉ chi nhánh ghi đầy đủ, rõ ràng chi tiết nhất: Ví dụ Số 88 Quan Hoa, Nguyễn Khánh Toàn, Cầu Giấy, Hà Nội
        public string diaChiCN { get; set; }
        public string ghiChu { get; set; }
        public string trangThai { get; set; }
    }
}
