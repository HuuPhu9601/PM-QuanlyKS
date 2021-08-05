using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Project_DATN.Data.EF.Entities.Enums;

namespace Project_DATN.Data.EF.Entities
{
    public class ChucVu
    {
        public int ID { get; set; }
        public int ID_TaiKhoan { get; set; }
        public int ID_PhongBan { get; set; }
        [Display(Name = "Áp dụng cho tài khoản")]
        public TaiKhoan TaiKhoan { get; set; }
        [Display(Name = "Thuộc phòng ban")]
        public PhongBan PhongBan { get; set; }
        [Display(Name = "Tên chức vụ")]
        [Required(ErrorMessage = "Mời bạn nhập tên chức vụ")]
        public string tenChucVu { get; set; }
        //Ngày bắt đầu áp dụng chức vụ
        [Display(Name = "Ngày bắt đầu áp dụng")]
        [Required(ErrorMessage = "Mời bạn thiết lập ngày bắt đầu áp dụng")]
        public DateTime ngayBatDauApDung { get; set; }
        //Đến ngày nhận chức vụ mới
        [Display(Name = "Ngày ngừng áp dụng chức vụ")]
        public DateTime? denNgay { get; set; }
        [Display(Name = "Ghi chú")]
        public string ghiChu { get; set; }
        [Display(Name = "Trạng thái hoạt động")]
        public TrangThai trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
    }
}
