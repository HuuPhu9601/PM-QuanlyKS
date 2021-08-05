using Microsoft.EntityFrameworkCore;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.ManhIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.Services.ManhServices
{
    public class HoaDonChiTietService : IHoaDonChiTietService
    {
        private readonly DB_Context _Context;
        public HoaDonChiTietService(DB_Context context)
        {
            _Context = context;
        }
        //Thêm hoá đơn chi tiết
        public bool AddChiTietHoaDon(ChiTiet_HoaDon cthd)
        {
            if (cthd != null)
            {
                var chiTietHoaDon = new ChiTiet_HoaDon()
                {
                    ID_DichVu = cthd.ID_DichVu,
                    ID_HoaDon = cthd.ID_HoaDon,
                    soLuongDichVu = cthd.soLuongDichVu,
                    trangThai = cthd.trangThai
                };
                _Context.ChiTietHoaDons.Add(chiTietHoaDon);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteChiTietHoaDon(int idCthd)
        {
            var delete = _Context.ChiTietHoaDons.Find(idCthd);
                _Context.ChiTietHoaDons.Remove(delete);
                _Context.SaveChanges();
                return true;
        }

        public bool EditChiTietHoaDon(ChiTiet_HoaDon cthd)
        {
            var editHoaDon = _Context.ChiTietHoaDons.FirstOrDefault(x => x.ID == cthd.ID);
            if (cthd == null)
            {
                return false;
            }
            else
            {
                editHoaDon.ID_DichVu = cthd.ID_DichVu;
                editHoaDon.ID_HoaDon = cthd.ID_HoaDon;
                editHoaDon.soLuongDichVu = cthd.soLuongDichVu;
                editHoaDon.ghiChu = cthd.ghiChu;
                editHoaDon.trangThai = cthd.trangThai;
                _Context.ChiTietHoaDons.Update(editHoaDon);
                _Context.SaveChanges();
                return true;
            }
        }

        public List<ChiTiet_HoaDon> GetAll()
        {
            //return _Context.ChiTietHoaDons.Select(x => new ChiTiet_HoaDon()
            //{
            //    ID = x.ID,
            //    ID_DichVu = x.ID_DichVu,
            //    ID_HoaDon = x.ID_HoaDon,
            //    HoaDon = x.HoaDon,
            //    DichVu = x.DichVu,
            //    soLuongDichVu = x.soLuongDichVu,
            //    ghiChu = x.ghiChu,
            //    trangThai = x.trangThai
            //}).ToList();
            return _Context.ChiTietHoaDons.Include(x => x.DichVu).Include(x => x.HoaDon).ToList();
        }

        public ChiTiet_HoaDon GetChiTietHoaDon(int idCtHoaDon)
        {
            return _Context.ChiTietHoaDons.Find(idCtHoaDon);
        }
    }
}
