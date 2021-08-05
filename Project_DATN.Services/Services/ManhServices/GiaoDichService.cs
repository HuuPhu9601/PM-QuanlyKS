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
    public class GiaoDichService : IGiaoDichService
    {
        private readonly DB_Context _Context;
        public GiaoDichService(DB_Context context)
        {
            _Context = context;
        }

        public bool AddGiaoDich(GiaoDich gd)
        {
            if (gd != null)
            {
                var GiaoDich = new GiaoDich()
                {
                    loaiHinhThucThanhToan = gd.loaiHinhThucThanhToan,
                    ngayGioThanhToan = DateTime.Now,
                    trangThai = gd.trangThai
                };
                _Context.GiaoDichs.Add(GiaoDich);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteGiaoDich(int id)
        {
            var findGD =  _Context.GiaoDichs.Find(id);
            if (findGD == null)
            {
                return false;
            }
            else
            {
                _Context.GiaoDichs.Remove(findGD);
                _Context.SaveChanges();
                return true;
            }
        }

        public bool EditGiaoDich(GiaoDich gd)
        {
            var findGiaoDich = _Context.GiaoDichs.FirstOrDefault(x => x.ID == gd.ID);
            if (findGiaoDich == null)
            {
                return false;
            }
            else
            {
                findGiaoDich.loaiHinhThucThanhToan = gd.loaiHinhThucThanhToan;
                //findGiaoDich.ngayGioThanhToan = gd.ngayGioThanhToan;
                findGiaoDich.trangThai = gd.trangThai;
                _Context.GiaoDichs.Update(findGiaoDich);
                _Context.SaveChanges();
                return true;
            }
        }

        public List<GiaoDich> GetAllGiaoDich()
        {
            return  _Context.GiaoDichs.Select(x=> new GiaoDich()
            { 
                ID = x.ID,
                loaiHinhThucThanhToan = x.loaiHinhThucThanhToan,
                ngayGioThanhToan = x.ngayGioThanhToan,
                trangThai = x.trangThai
            }).ToList();
        }

        public GiaoDich GetGiaoDich(int idGiaoDich)
        {
            return  _Context.GiaoDichs.Find(idGiaoDich);
        }
    }
}
