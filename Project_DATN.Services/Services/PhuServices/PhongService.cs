using Microsoft.EntityFrameworkCore;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.DataProviders;
using Project_DATN.Services.IServices.PhuIServices;
using Project_DATN.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.Services.PhuServices
{
    public class PhongService : IPhongService
    {
        public async Task<bool> CraetePhong(Phong phong)
        {
            if (phong == null)
            {
                return false;
            }
            DataProvider.Ins.DB.Phongs.Add(phong);
            await DataProvider.Ins.DB.SaveChangesAsync();
            return true;
        }

        public async Task<List<Phong>> GetAll()
        {
            var result = await DataProvider.Ins.DB.Phongs.Select(x=> new Phong{ 
             CoSo = x.CoSo,
             ghiChu = x.ghiChu,
             ID = x.ID,
             ID_CoSo = x.ID_CoSo,
             ID_Lau = x.ID_Lau,
             ID_LoaiPhong = x.ID_LoaiPhong,
             Lau = x.Lau,
             LoaiPhong = x.LoaiPhong,
             tenPhong = x.tenPhong,
             trangThai = x.trangThai
            }).OrderByDescending(x=>x.ID).ToListAsync();
            return result;
        }

        public async Task<Phong> GetPhongById(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var result = await DataProvider.Ins.DB.Phongs.FindAsync(id);
            return result;
        }

        public async Task<bool> RemovePhong(int id)
        {
            if (id == 0)
            {
                return false;
            }
            var result = await DataProvider.Ins.DB.Phongs.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            DataProvider.Ins.DB.Phongs.Remove(result);
            await DataProvider.Ins.DB.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePhong(int id, Phong phong)
        {
            if (id == 0 || phong == null)
            {
                return false;
            }
            var result = await DataProvider.Ins.DB.Phongs.FindAsync(id);
            if (result == null)
            {
                return false;
            }

            result.tenPhong = phong.tenPhong;
            result.trangThai = phong.trangThai;
            result.ghiChu = phong.ghiChu;
            result.ID_LoaiPhong = phong.ID_LoaiPhong;
            result.ID_CoSo = phong.ID_CoSo;
            result.ID_Lau = phong.ID_Lau;
            DataProvider.Ins.DB.Phongs.Update(result);
            await DataProvider.Ins.DB.SaveChangesAsync();
            return true;
        }
    }
}
