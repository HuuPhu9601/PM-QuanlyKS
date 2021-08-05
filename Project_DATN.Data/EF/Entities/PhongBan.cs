using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Project_DATN.Data.EF.Entities.Enums;

namespace Project_DATN.Data.EF.Entities
{
    public class PhongBan
    {
        //public Guid ID { get; set; }
        public int ID { get; set; }
        public int ID_LoaiPhongBan { get; set; }
        [Display(Name = "Thuộc loại phòng ban")]
        public LoaiPhongBan LoaiPhongBan { get; set; }
        [Display(Name = "Tên phòng ban")]
        [Required(ErrorMessage = "Mời bạn nhập tên phòng ban")]
        public string tenPhongBan { get; set; }
        [Display(Name = "Số lượng phòng ban")]
        [Required(ErrorMessage = "Mời bạn nhập số lượng phòng ban")]
        public int soLuongPhongBan { get; set; }
        [Display(Name = "Số lượng nhân viên một phòng ban")]
        [Required(ErrorMessage = "Mời bạn nhập số lượng nhân viên của một phòng ban")]
        public int soLuongNhanVien { get; set; }
        [Display(Name = "Ghi Chú")]
        public string ghiChu { get; set; }
        [Display(Name = "Trạng thái")]
        public TrangThai trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<TaiKhoan> ICTaiKhoan { get; set; }
        public ICollection<ChucVu> ICChucVu { get; set; }
    }
}
