using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project_DATN.Data.EF.Entities
{
    public class LoaiDichVu
    {
        public int ID { get; set; }
        [Display(Name = "Tên dịch vụ")]
        [StringLength(32, MinimumLength = 5, ErrorMessage = "Tên dịch vụ phải có độ dài 5 - 32 ký tự")]
        public string tenLoaiDichVu { get; set; }
        [Display(Name = "Tên mô tả")]
     
        public string moTa { get; set; }
        [Display(Name = "Trạng thái")]
        public string trangThai { get; set; }
        public string fields1 { get; set; }
        public string fields2 { get; set; }
        public string fields3 { get; set; }
        public string fields4 { get; set; }
        public string fields5 { get; set; }
        public ICollection<DichVu> ICDichVu { get; set; }

    }
}
