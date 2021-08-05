using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class CoSo
    {
        public int ID { get; set; }
        public int ID_Tinh_TP { get; set; }
        public int ID_Quan_Huyen { get; set; }
        public int ID_TK_NH { get; set; }
        public Tinh_ThanhPho TinhThanhPho { get; set; }
        public Quan_Huyen QuanHuyen { get; set; }
        public TaiKhoan_NganHang TaiKhoanNganHang { get; set; }
        //Với mỗi cơ sở nào có nhiều nhà nghỉ/ khách sạn thì hiển thị mã là: CS...1, CS...2
        //(...: có nhiều chữ số dùng khi có chục/ trăm cơ sở :V)
        //Với cơ sở nào chi có 1 NN/KS thì không cần hiển thị mã 
        public string maCoSo { get; set; }
        public string tenCoSo { get; set; }
        public string hoTenNguoiDaiDien { get; set; }
        public string maSoThue { get; set; }
        public string soDienThoai { get; set; }
        public string email { get; set; }
        public string ghiChu { get; set; }
        public string trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<Lau> ICLau { get; set; }
        public ICollection<Phong> ICPhong { get; set; }
        public ICollection<TaiKhoan> ICTaiKhoan { get; set; }

    }
}
