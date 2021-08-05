using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.IServices
{
    public interface ICheckInCheckOutService
    {
        public bool UpdateThoiGianTraPhong(HoaDon hoaDon);
        public bool CheckOut(HoaDon hoaDon);
        public bool CheckIn(HoaDon hoaDon,int idPhong);
        public bool AddDichVu(ChiTiet_HoaDon cthd);
        public Task<int> ThuePhong(KhachHang khach,int idPhong);
    }
}
