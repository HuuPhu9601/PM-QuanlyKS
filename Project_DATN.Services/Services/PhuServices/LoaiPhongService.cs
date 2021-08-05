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
    public class LoaiPhongService : ILoaiPhongService
    {
        public async Task<bool> CraeteLoaiPhong(LoaiPhong tknh)
        {
            if (tknh == null)
            {
                return false;
            }
            DataProvider.Ins.DB.LoaiPhongs.Add(tknh);
            await DataProvider.Ins.DB.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddQRcode(LoaiPhong lp)
        {
            if (lp.ID == 0 || lp.fields1 == null)
            {
                return false;
            }
            DataProvider.Ins.DB.LoaiPhongs.Update(lp);
            await DataProvider.Ins.DB.SaveChangesAsync();
            return true;
        }

        public async Task<List<LoaiPhong>> GetAll()
        {
            var result = await DataProvider.Ins.DB.LoaiPhongs.ToListAsync();
            return result;
        }

        public async Task<LoaiPhong> GetLoaiPhongById(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var result = await DataProvider.Ins.DB.LoaiPhongs.FindAsync(id);
            return result;
        }

        public async Task<bool> RemoveLoaiPhong(int id)
        {
            if (id == 0)
            {
                return false;
            }
            var result = await DataProvider.Ins.DB.LoaiPhongs.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            DataProvider.Ins.DB.LoaiPhongs.Remove(result);
            await DataProvider.Ins.DB.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateLoaiPhong(int id, LoaiPhong tknh)
        {
            if (id == 0 || tknh == null)
            {
                return false;
            }
            var result = await DataProvider.Ins.DB.LoaiPhongs.FindAsync(id);
            if (result == null)
            {
                return false;
            }

            result.tenLoaiPhong = tknh.tenLoaiPhong;
            result.soNguoi = tknh.soNguoi;
            result.trangThai = tknh.trangThai;
            result.ghiChu = tknh.ghiChu;
            result.donGiaQuaDem = tknh.donGiaQuaDem;
            result.donGiaTheoGio = tknh.donGiaTheoGio;
            result.donGiaTheoNgay = tknh.donGiaTheoNgay;

            DataProvider.Ins.DB.LoaiPhongs.Update(result);
            await DataProvider.Ins.DB.SaveChangesAsync();
            return true;
        }
    }
}
