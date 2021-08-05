using Microsoft.EntityFrameworkCore;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.DataProviders;
using Project_DATN.Services.IServices.PhuIServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.Services.PhuServices
{
    public class TaiKhoanNganHangService : TaiKhoanNganHangIService
    {
        public async Task<bool> CraeteTKNH(TaiKhoan_NganHang tknh)
        {
            if (tknh == null)
            {
                return false;
            }
            DataProvider.Ins.DB.TaiKhoanNganHangs.Add(tknh);
            await DataProvider.Ins.DB.SaveChangesAsync();
            return true;
        }

        public async Task<List<TaiKhoan_NganHang>> GetAll()
        {
            var result = await DataProvider.Ins.DB.TaiKhoanNganHangs.ToListAsync();
            return result;
        }

        public async Task<TaiKhoan_NganHang> GetTKById(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var result = await DataProvider.Ins.DB.TaiKhoanNganHangs.FindAsync(id);
            return result;
        }

        public async Task<bool> RemoveTKNH(int id)
        {
            if (id == 0)
            {
                return false;
            }
            var result = await DataProvider.Ins.DB.TaiKhoanNganHangs.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            DataProvider.Ins.DB.TaiKhoanNganHangs.Remove(result);
            await DataProvider.Ins.DB.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateTKNH(int id, TaiKhoan_NganHang tknh)
        {
            if (id == 0 || tknh == null)
            {
                return false;
            }
            var result = await DataProvider.Ins.DB.TaiKhoanNganHangs.FindAsync(id);
            if (result == null)
            {
                return false;
            }

            result.ghiChu = tknh.ghiChu;
            result.hoTenChuTKNH = tknh.hoTenChuTKNH;
            result.soTaiKhoan = tknh.soTaiKhoan;
            result.tenChiNhanh = tknh.tenChiNhanh;
            result.diaChiCN = tknh.diaChiCN;
            result.trangThai = tknh.trangThai;
            result.tenNganHang = tknh.tenNganHang;

            DataProvider.Ins.DB.TaiKhoanNganHangs.Update(result);
            await DataProvider.Ins.DB.SaveChangesAsync();
            return true;
        }
    }
}
