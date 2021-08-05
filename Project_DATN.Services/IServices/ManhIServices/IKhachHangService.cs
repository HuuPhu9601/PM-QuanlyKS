using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.IServices.ManhIServices
{
    public interface IKhachHangService
    {
        public List<KhachHang> GetAllKhachHang();
        public KhachHang GetKhachHang(int idKhachHang);
        public bool AddKhachHang(KhachHang kh);
        public bool EditKhachHang(KhachHang kh);
        public bool DeleteKhachHang(int idKhachHang);
    }
}
