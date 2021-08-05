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
    public class LauService : ILauService
    {
        public async Task<bool> CraeteLau(Lau cs)
        {
            if (cs == null)
            {
                return false;
            }
            DataProvider.Ins.DB.Laus.Add(cs);
            await DataProvider.Ins.DB.SaveChangesAsync();
            return true;
        }

        public async Task<List<LauRequest>> GetAll()
        {
            var result = await DataProvider.Ins.DB.Laus.Select(
                i => new LauRequest()
                {
                    Id = i.ID,
                   tencoso = i.CoSo.tenCoSo,
                   ghiChu = i.ghiChu,
                   ID_CoSo = i.ID_CoSo,
                   SoLuongPhong = i.soLuongLau,
                   tenLau = i.tenLau,
                   trangThai = i.trangThai
                }
                ).ToListAsync();
            return result;
        }

        public async Task<Lau> GetLauById(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var result = await DataProvider.Ins.DB.Laus.FindAsync(id);
            return result;
        }

        public async Task<bool> RemoveLau(int id)
        {
            if (id == 0)
            {
                return false;
            }
            var result = await DataProvider.Ins.DB.Laus.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            var ListPhong = await DataProvider.Ins.DB.Phongs.Where(x => x.ID_Lau == result.ID).ToListAsync();
            if (ListPhong.Count > 0)
            {
                foreach (var item in ListPhong)
                {
                    DataProvider.Ins.DB.Phongs.Remove(item);
                }
            }
            DataProvider.Ins.DB.Laus.Remove(result);
            await DataProvider.Ins.DB.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateLau(int id, Lau cs)
        {
            if (id == 0 || cs == null)
            {
                return false;
            }
            var result = await DataProvider.Ins.DB.Laus.FindAsync(id);
            if (result == null)
            {
                return false;
            }

            result.trangThai = cs.trangThai;
            result.tenLau = cs.tenLau;
            result.soLuongLau = cs.soLuongLau;
            result.ghiChu = cs.ghiChu;

            DataProvider.Ins.DB.Laus.Update(result);
            await DataProvider.Ins.DB.SaveChangesAsync();
            return true;
        }
    }
}
