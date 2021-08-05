using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.IServices.PhuIServices
{
    public interface TaiKhoanNganHangIService
    {
        public Task<List<TaiKhoan_NganHang>> GetAll();

        public Task<TaiKhoan_NganHang> GetTKById(int id);

        public Task<bool> CraeteTKNH(TaiKhoan_NganHang tknh);

        public Task<bool> UpdateTKNH(int id, TaiKhoan_NganHang tknh);

        public Task<bool> RemoveTKNH(int id);
    }
}
