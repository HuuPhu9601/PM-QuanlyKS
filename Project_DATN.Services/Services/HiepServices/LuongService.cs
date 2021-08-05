using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.HiepIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_DATN.Services.Services.HiepServices
{
    public class LuongService : ILuongService
    {
        private readonly DB_Context _Context;
        public LuongService(DB_Context context)
        {
            _Context = context;
        }

        public bool AddLuong(Luong lg)
        {

            if (lg != null)
            {
                var Luong = new Luong()
                {
                    ID_TaiKhoan= lg.ID_TaiKhoan,
                    ngayBatDauApDung=lg.ngayBatDauApDung,
                    denNgay=lg.denNgay,
                    tienThucLinh=lg.tienThucLinh,
                    donViTinhTien=lg.donViTinhTien,
                    ghiChu=lg.ghiChu,
                    trangThai=lg.trangThai,
                   
                };
                _Context.Luongs.Add(Luong);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteLuong(int id)
        {
            var findLg = _Context.Luongs.Find(id);
            if (findLg == null)
            {
                return false;
            }
            else
            {
                _Context.Luongs.Remove(findLg);
                _Context.SaveChanges();
                return true;
            }
        }

        public bool EditLuong(Luong lg)
        {
            var FindLuong = _Context.Luongs.FirstOrDefault(x => x.ID == lg.ID);
            if (FindLuong == null)
            {
                return false;
            }
            else
            {
                FindLuong.ID_TaiKhoan = lg.ID_TaiKhoan;
                FindLuong.ngayBatDauApDung = lg.ngayBatDauApDung;
                FindLuong.denNgay = lg.denNgay;
                FindLuong.tienThucLinh = lg.tienThucLinh;
                FindLuong.donViTinhTien = lg.donViTinhTien;
                FindLuong.ghiChu = lg.ghiChu;
                FindLuong.trangThai = lg.trangThai;

                _Context.Luongs.Update(FindLuong);
                _Context.SaveChanges();
                return true;
            }
        }

        public List<Luong> GetAllLuong()
        {
            return _Context.Luongs.Select(x => new Luong()
            {
                ID = x.ID,
                ID_TaiKhoan = x.ID_TaiKhoan,
                ngayBatDauApDung = x.ngayBatDauApDung,
                denNgay=x.denNgay,
                tienThucLinh=x.tienThucLinh,
                ghiChu=x.ghiChu,
              
                trangThai = x.trangThai
            }).ToList();
        }

        public Luong GetLuong(int IdLuong)
        {
            return _Context.Luongs.Find(IdLuong);
        }
    }
}