using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class GiaoCa
    {
        public int ID { get; set; }
        public int ID_TaiKhoan { get; set; }
        public TaiKhoan TaiKhoan { get; set; }

        [Display(Name = "Ca làm")]
        public string caLam { get; set; }
        [Display(Name = "Thời điểm giao ca")]
        public DateTime thoiDiemGiaoCa { get; set; }

        [Display(Name = "Số tiền đầu ca ")]
        [Phone(ErrorMessage = "Vui lòng điền số ")]
        public decimal tongTienDauCa { get; set; }

        [Display(Name = "Số tiền chênh ")]

        public decimal tongTienChenh { get; set; }

        [Display(Name = "Số lượng hóa đơn")]

        public int soLuongHoaDon { get; set; }
        [Display(Name = "Ghi chú")]

        public string ghiChu { get; set; }
        [Display(Name = "Trạng thái")]

        public string trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<HoaDon> ICHoaDon { get; set; }
    }
}
