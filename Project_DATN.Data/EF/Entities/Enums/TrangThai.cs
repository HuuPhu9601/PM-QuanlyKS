using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DATN.Data.EF.Entities.Enums
{
    public enum TrangThai
    {
        [Display(Name = "Hoạt động")]
        HoatDong,
        [Display(Name = "Không hoạt động")]
        KhongHoatDong
    }
}
