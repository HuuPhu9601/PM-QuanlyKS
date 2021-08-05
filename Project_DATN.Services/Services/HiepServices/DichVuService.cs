using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.HiepIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_DATN.Services.Services.HiepServices
{
    public class DichVuService : IDichVuService
    {
        private readonly DB_Context _Context;
        public DichVuService(DB_Context context)
        {
            _Context = context;
        }

        public bool AddDichVu(DichVu dv)
        {
            if (dv != null)
            {
                var DichVu = new DichVu()
                {
                    ID_LoaiDichVu = dv.ID_LoaiDichVu,
                    tenDichVu = dv.tenDichVu,
                    donViTinh=dv.donViTinh,
                    donGia=dv.donGia,
                    donViTien=dv.donViTien,
                    moTa=dv.moTa,
                    trangThai = dv.trangThai,
                };
                _Context.DichVus.Add(DichVu);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteDichVu(int id)
        {
            var findDV = _Context.DichVus.Find(id);
            if (findDV == null)
            {
                return false;
            }
            else
            {
                _Context.DichVus.Remove(findDV);
                _Context.SaveChanges();
                return true;
            }
        }

        public bool EditDichVu(DichVu dv)
        {
            var findDichVu = _Context.DichVus.FirstOrDefault(x => x.ID == dv.ID);
            if (findDichVu == null)
            {
                return false;
            }
            else
            {
                findDichVu.ID_LoaiDichVu = dv.ID_LoaiDichVu;
                findDichVu.tenDichVu = dv.tenDichVu;
                findDichVu.donViTinh = dv.donViTinh;
                findDichVu.donGia = dv.donGia;

                findDichVu.donViTien = dv.donViTien;
                findDichVu.moTa = dv.moTa;
                findDichVu.trangThai = dv.trangThai;
                _Context.DichVus.Update(findDichVu);
                _Context.SaveChanges();
                return true;
            }
        }
        public List<DichVu> GetAllDichVu()
        {
            return _Context.DichVus.Select(x => new DichVu()
            {
                ID = x.ID,
                ID_LoaiDichVu = x.ID_LoaiDichVu,
                tenDichVu = x.tenDichVu,
                donViTinh = x.donViTinh,
                donGia = x.donGia,
                donViTien = x.donViTien,
                moTa = x.moTa,
                trangThai = x.trangThai
            }).ToList();
        }

        public DichVu GetDichVu(int idDichVu)
        {

            return _Context.DichVus.Find(idDichVu);
        }
    }
}
