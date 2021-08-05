using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.duongpro99vipIService;

namespace Project_DATN.Services.Services.duongpro99vipService
{
    public class PhongBanService : IPhongBanService
    {
        private readonly DB_Context _dbContext;

        public PhongBanService(DB_Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PhongBan> Create(PhongBan phongBan)
        {
            _dbContext.PhongBans.Add(phongBan);
            await _dbContext.SaveChangesAsync();
            return phongBan;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PhongBan> Edit(PhongBan phongBan)
        {
            throw new NotImplementedException();
        }

        public PhongBan FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<PhongBan> GetAllPhongBan()
        {
            throw new NotImplementedException();
        }
        //public bool Crete(ChucVu chucVu)
        //{
        //    if (chucVu != null)
        //    {
        //        var cV = new ChucVu()
        //        {
        //            ID_PhongBan = chucVu.ID_PhongBan,
        //            ID_TaiKhoan = chucVu.ID_TaiKhoan,
        //            tenChucVu = chucVu.tenChucVu,
        //            ngayBatDauApDung = chucVu.ngayBatDauApDung,
        //            denNgay = chucVu.denNgay,
        //            ghiChu = chucVu.ghiChu,
        //            trangThai = chucVu.trangThai
        //        };
        //        _dbContext.ChucVus.Add(chucVu);
        //        _dbContext.SaveChanges();
        //        return true;
        //    }

        //    return false;
        //}

        //public bool DeleteChucVu(int ID)
        //{
        //    var deletechucVu = _dbContext.ChucVus.Find(ID);
        //    if (deletechucVu != null)
        //    {
        //        _dbContext.ChucVus.Remove(deletechucVu);
        //        _dbContext.SaveChanges();
        //        return true;
        //    }
        //    return false;

        //}

        //public bool EditChucVu(ChucVu chucVu)
        //{
        //    var editChucVu = _dbContext.ChucVus.FirstOrDefault(x => x.ID == chucVu.ID);
        //    if (editChucVu != null)
        //    {
        //        editChucVu.tenChucVu = chucVu.tenChucVu;
        //        editChucVu.denNgay = chucVu.denNgay;
        //        editChucVu.ghiChu = chucVu.ghiChu;
        //        editChucVu.trangThai = chucVu.trangThai;
        //        _dbContext.ChucVus.UpdateRange(editChucVu);
        //        _dbContext.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}

        //public List<ChucVu> GetAllChucVus()
        //{
        //    return _dbContext.ChucVus.Include(cV => cV.TaiKhoan).Include(cV => cV.PhongBan).ToList();
        //}

        //public ChucVu GetChucVu(int ID)
        //{
        //    return _dbContext.ChucVus.Find(ID);
        //}
    }
}
