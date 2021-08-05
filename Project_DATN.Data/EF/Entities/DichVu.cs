using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class DichVu
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng chọn một loại dịch vụ")]
        public int ID_LoaiDichVu { get; set; }
        public virtual LoaiDichVu LoaiDichVu { get; set; }
        //Tên dịch vụ: Nước khoáng...
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mời nhập tên dịch vụ")]
        [Display(Name = "Tên dịch vụ")]
        public string tenDichVu { get; set; }

        [Display(Name = "Đơn vị tính")]

        //Đơn vị tính: Chiếc/ cái/ bao...
        public string donViTinh { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mời nhập đơn giá")]
        [Display(Name = "Đơn giá")]
        public decimal donGia { get; set; }
        //Đơn vị tính: VNĐ

        [Display(Name = "Đơn vị tiền")]
        public string donViTien { get; set; }

        [Display(Name = "Mô tả")]
        public string moTa { get; set; }

        [Display(Name = "Trạng thái")]
        public string trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<ChiTiet_HoaDon> ICChiTietHoaDon { get; set; }
    }
}
