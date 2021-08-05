using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.IServices.ManhIServices
{
    public interface IBookingServices
    {
        bool nhanPhong(HoaDon hoaDon, int idPhong);
        bool traPhong(HoaDon hoaDon);
        void hienThiHoaDon();
        bool thanhToanHoaDon(HoaDon hoaDon);
        Task<int> themDichVuSuDung(ChiTiet_HoaDon chiTiet_Hoa, int idPhong);
        Task<int> updateDichVuSuDung(ChiTiet_HoaDon chiTiet_Hoa, int soLuong);
        Task<int> xoaDichVuSuDung(int id);
        Task<List<ChiTiet_HoaDon>> hienThiDichVuSuDung();
        bool ChuyenPhong(HoaDon hoaDon, int idphongchuyen);
       
    }
}
