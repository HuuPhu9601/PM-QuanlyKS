using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class DatPhong
    {
        public int ID { get; set; }
        public int ID_KhachHang { get; set; }
        public int ID_LoaiPhong { get; set; }
        public KhachHang KhachHang { get; set; }
        public LoaiPhong LoaiPhong { get; set; }
        public string maDatPhong { get; set; }
        public DateTime ngayGioDat { get; set; }
        //Thời gian lưu trú: Đặt trước x ngày y đêm chẳng hạn
        public string thoiGianLuuTru { get; set; }
        //Số lượng khách sử dụng phòng
        public int soLuongKhach { get; set; }
        //Số lượng phòng cần đặt trước
        public int soLuongPhongDat { get; set; }
        //Cho phép khách mang thú cưng chó/ mèo vào, cho vào phòng riêng cho chó mèo
        public string thuCung { get; set; }
        //Ghi chú những yêu cầu đặc biệt của khách 
        public string ghiChu { get; set; }
        //Trạng thái: Huỷ đặt/ Đặt thành công...
        public string trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<HoaDon> ICHoaDon { get; set; }
    }
}
