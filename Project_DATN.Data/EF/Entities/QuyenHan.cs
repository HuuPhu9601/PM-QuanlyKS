using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Project_DATN.Data.EF.Entities.Enums;

namespace Project_DATN.Data.EF.Entities
{
    public class QuyenHan
    {
        public int ID { get; set; }
        //Tên của quyền: Chủ/Quản lý/ Lễ tân...
        [Display(Name = "Tên quyền hạn")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "Nhập tên quyền hạn")]
        public string tenQuyenHan { get; set; }
        [Display(Name = "Mô tả")]
        public string moTa { get; set; }
        [Display(Name = "Trạng thái")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nhập trạng thái quyền hạn")]
        public TrangThai trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<ChiTiet_QuyenHan> IC_ChiTiet_QuyenHan { get; set; }
        public ICollection<TaiKhoan_QuyenHan> IC_TK_QH { get; set; }
    }
}
