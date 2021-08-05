using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.IServices.ManhIServices
{
    public interface IHoaDonChiTietService
    {
        public List<ChiTiet_HoaDon> GetAll();
        public ChiTiet_HoaDon GetChiTietHoaDon(int idCtHoaDon);
        public bool AddChiTietHoaDon(ChiTiet_HoaDon cthd);
        public bool EditChiTietHoaDon(ChiTiet_HoaDon cthd);
        public bool DeleteChiTietHoaDon(int idCtHoaDon);
    }
}
