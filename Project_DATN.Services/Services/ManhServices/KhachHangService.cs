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
    public class KhachHangService : IKhachHangService
    {
        private readonly DB_Context _Context;
        public KhachHangService(DB_Context context)
        {
            _Context = context;
        }

        public bool AddKhachHang(KhachHang kh)
        {
            if (kh != null)
            {
                var khachHang = new KhachHang()
                {
                    maKH = kh.maKH,
                    hoTenKH = kh.hoTenKH,
                    gioiTinh = kh.gioiTinh,
                    CCCD = kh.CCCD,
                    quocTich = kh.quocTich,
                    soDienThoai = kh.soDienThoai,
                    email = kh.email,
                    diaChi = kh.diaChi,
                    trangThai = kh.trangThai
                };
                _Context.KhachHangs.Add(khachHang);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteKhachHang(int idKh)
        {
            var deleteKhachHang = _Context.KhachHangs.Find(idKh);
            if (deleteKhachHang == null)
            {
                return false;
            }
            else
            {
                _Context.KhachHangs.Remove(deleteKhachHang);
                _Context.SaveChanges();
                return true;
            }
        }

        public bool EditKhachHang(KhachHang kh)
        {
            var editKhachHang = _Context.KhachHangs.FirstOrDefault(x => x.ID == kh.ID);
            if (editKhachHang == null)
            {
                return false;
            }
            else
            {
                editKhachHang.maKH = kh.maKH;
                editKhachHang.hoTenKH = kh.hoTenKH;
                editKhachHang.gioiTinh = kh.gioiTinh;
                editKhachHang.CCCD = kh.CCCD;
                editKhachHang.quocTich = kh.quocTich;
                editKhachHang.soDienThoai = kh.soDienThoai;
                editKhachHang.email = kh.email;
                editKhachHang.diaChi = kh.diaChi;
                editKhachHang.trangThai = kh.trangThai;
                _Context.KhachHangs.UpdateRange(editKhachHang);
                _Context.SaveChanges();
                return true;
            }
        }

        public List<KhachHang> GetAllKhachHang()
        {
            return _Context.KhachHangs.ToList();
            //return _Context.KhachHangs.Select(x => new KhachHang()
            //{
            //    ID = x.ID,
            //    maKH = x.maKH,
            //    hoTenKH = x.hoTenKH,
            //    email = x.email,
            //    soDienThoai = x.soDienThoai,
            //    gioiTinh = x.gioiTinh,
            //    CCCD = x.CCCD,
            //    quocTich = x.quocTich,
            //    diaChi = x.diaChi,
            //    trangThai = x.trangThai
            //}).ToList();
        }

        public KhachHang GetKhachHang(int idKhachHang)
        {
            var KhachHang =_Context.KhachHangs.Find(idKhachHang);
            return KhachHang;
        }
    }
}
