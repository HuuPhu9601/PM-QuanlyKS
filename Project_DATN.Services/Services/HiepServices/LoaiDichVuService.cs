using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.HiepIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_DATN.Services.Services.HiepServices
{
   public class LoaiDichVuService : ILoaiDichVuService
    {
        private readonly DB_Context _Context;
        public LoaiDichVuService(DB_Context context)
        {
            _Context = context;
        }

        public bool AddLoaiDichVu(LoaiDichVu ldv)
        {
            if (ldv != null)
            {
                var LoaiDichVu = new LoaiDichVu()
                {
                    tenLoaiDichVu = ldv.tenLoaiDichVu,
                   
                    moTa = ldv.moTa,
                    trangThai = ldv.trangThai,
                };
                _Context.LoaiDichVus.Add(LoaiDichVu);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteLoaiDichVu(int id)
        {
            var findLDV = _Context.LoaiDichVus.Find(id);
            if (findLDV == null)
            {
                return false;
            }
            else
            {
                _Context.LoaiDichVus.Remove(findLDV);
                _Context.SaveChanges();
                return true;
            }
        }

        public bool EditLoaiDichVu(LoaiDichVu ldv)
        {
            var findLoaiDichVu = _Context.LoaiDichVus.FirstOrDefault(x => x.ID == ldv.ID);
            if (findLoaiDichVu == null)
            {
                return false;
            }
            else
            {
                findLoaiDichVu.tenLoaiDichVu = ldv.tenLoaiDichVu;
                findLoaiDichVu.moTa = ldv.moTa;
                findLoaiDichVu.trangThai = ldv.trangThai;
               
                _Context.LoaiDichVus.Update(findLoaiDichVu);
                _Context.SaveChanges();
                return true;
            }
        }

        public List<LoaiDichVu> GetAllLoaiDichVu()
        {
            return _Context.LoaiDichVus.Select(x => new LoaiDichVu()
            {
                ID = x.ID,
                tenLoaiDichVu = x.tenLoaiDichVu,

                moTa = x.moTa,
                trangThai = x.trangThai
            }).ToList();
        }

        public LoaiDichVu GetLoaiDichVu(int idLoaiDichVu)
        {
            return _Context.LoaiDichVus.Find(idLoaiDichVu);
        }
    }
}