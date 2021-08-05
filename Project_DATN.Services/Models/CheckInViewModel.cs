using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.Models
{
    public class CheckInViewModel
    {
        public HoaDon HoaDon { set; get; }
        public KhachHang KhachHang { set; get; }
    }
}
