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
    public class CosoService : ICosoService
    {
        public async Task<bool> CraeteCoso(CoSo cs)
        {
            if (cs == null)
            {
                return false;
            }
            try
            {
                DataProvider.Ins.DB.CoSos.Add(cs);

                await DataProvider.Ins.DB.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var eroor = e.Message;
                return false;
            }

            return true;
        }

        public async Task<List<CosoRequest>> GetAll()
        {
            var result = await DataProvider.Ins.DB.CoSos.Select(x => new CosoRequest()
            {
                Id = x.ID,
                email = x.email,
                ghiChu = x.ghiChu,
                hoTenNguoiDaiDien = x.hoTenNguoiDaiDien,
                ID_Quan_Huyen = x.ID_Quan_Huyen,
                ID_Tinh_TP = x.ID_Tinh_TP,
                ID_TK_NH = x.ID_TK_NH,
                maSoThue = x.maSoThue,
                tenCoSo = x.tenCoSo,
                trangThai = x.trangThai,
                soDienThoai = x.soDienThoai,
                Tinh_TP = x.TinhThanhPho.tenTinh,
                QuanHuyen = x.QuanHuyen.tenQuan_Huyen,
                Sotaikhoan = x.TaiKhoanNganHang.soTaiKhoan
            }).ToListAsync();
            
            return result;
        }

    public async Task<CoSo> GetCosoById(int id)
    {
        if (id == 0)
        {
            return null;
        }
        var result = await DataProvider.Ins.DB.CoSos.FindAsync(id);
        return result;
    }

    public async Task<bool> RemoveCoso(int id)
    {
        if (id == 0)
        {
            return false;
        }
        var result = await DataProvider.Ins.DB.CoSos.FindAsync(id);
        if (result == null)
        {
            return false;
        }
        result.trangThai = "close";
        DataProvider.Ins.DB.CoSos.Update(result);
        await DataProvider.Ins.DB.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateCoso(int id, CoSo cs)
    {
        if (id == 0 || cs == null)
        {
            return false;
        }
        var result = await DataProvider.Ins.DB.CoSos.FindAsync(id);
        if (result == null)
        {
            return false;
        }

        result.tenCoSo = cs.tenCoSo;
        result.email = cs.email;
        result.ghiChu = cs.ghiChu;
        result.hoTenNguoiDaiDien = cs.hoTenNguoiDaiDien;
        result.maSoThue = cs.maSoThue;
        result.soDienThoai = cs.soDienThoai;
        result.trangThai = cs.trangThai;

        DataProvider.Ins.DB.CoSos.Update(result);
        await DataProvider.Ins.DB.SaveChangesAsync();
        return true;
    }
}
}
