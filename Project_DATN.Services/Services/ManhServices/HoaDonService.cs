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
    public class HoaDonService : IHoaDonService
    {
        private readonly DB_Context _Context;
        public HoaDonService(DB_Context context)
        {
            _Context = context;
        }
        
        public List<HoaDon> getHoaDonByDate(DateTime to , DateTime from)
        {
         return _Context.HoaDons.Where(x => x.ngayGioLap >= to && x.ngayGioLap <= from).OrderByDescending(x => x.ngayGioLap).ToList();
           
        }
        public bool AddHoaDon(HoaDon hd,int idPhong)
        {
            var idHoaDon = _Context.HoaDons.Max(x => x.ID);
            var idKh = _Context.KhachHangs.Max(x => x.ID);
            var kh = new KhachHang()
            {
                hoTenKH = hd.KhachHang.hoTenKH,
                CCCD = hd.KhachHang.CCCD,
                diaChi = hd.KhachHang.diaChi,
                email = hd.KhachHang.email,
                gioiTinh = hd.KhachHang.gioiTinh,
                quocTich = hd.KhachHang.quocTich,
                soDienThoai = hd.KhachHang.soDienThoai,
                maKH = "KH0" + (idKh+1).ToString()
            };
            if (hd != null)
            {
                var phong = _Context.Phongs.Find(hd.ID_Phong);
                var hoaDon = new HoaDon()
                {

                    ID_Phong = idPhong,
                    ID_TaiKhoan = hd.ID_TaiKhoan,
                    ID_KhachHang = hd.KhachHang.ID,
                    ID_GiaoDich = hd.ID_GiaoDich,
                    ID_LoaiPhong = phong.ID_LoaiPhong,
                    ID_GiaoCa = hd.ID_GiaoCa,
                    KhachHang = kh,
                    maHoaDon = "HĐ0"+(idHoaDon +1).ToString(),
                    ngayGioLap = DateTime.Now,
                    ngayGioNhanPhong = DateTime.Now,
                    cocTien = hd.cocTien,
                    tienTraLai = hd.tienTraLai,
                    ghiChu = hd.ghiChu,
                    trangThai = "Chưa Trả Phòng"
                };
                
                phong.trangThai = "Có Người";
                _Context.Phongs.Update(phong);
                _Context.HoaDons.Add(hoaDon);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteHoaDon(int idHoaDon)
        {
            var delete = _Context.HoaDons.Find(idHoaDon);
            if (delete == null)
            {
                return false;
            }
            else
            {
                _Context.HoaDons.Remove(delete);
                _Context.SaveChanges();
                return true;
            }
        }
        public static DateTime Substract(DateTime now, int hours, int minutes, int seconds)
        {
            TimeSpan T1 = new TimeSpan(hours, minutes, seconds);
            return now.Subtract(T1);
        }
        public bool EditHoaDon(HoaDon hd)
        {
            var edit = _Context.HoaDons.FirstOrDefault(x => x.ID == hd.ID);
            if (hd != null)
            {
                edit.ngayGioTraPhong = DateTime.Now;
                edit.thoiGianThue = DateTime.Now.Subtract(edit.ngayGioNhanPhong).ToString();
                edit.chietKhau = hd.chietKhau;
                edit.phuThu = hd.phuThu;
                edit.giamGia = hd.giamGia;
                edit.giamTru = hd.giamTru;
                edit.thueVAT = hd.thueVAT;
                edit.tienKhachDua = hd.tienKhachDua;
                edit.tienTraLai = hd.tienTraLai;
                edit.ghiChu = hd.ghiChu;
                edit.trangThai = "Đã Thanh Toán";
                var phong = _Context.Phongs.Find(hd.ID_Phong);
                phong.trangThai = "Trống";
                _Context.Phongs.Update(phong);
                _Context.HoaDons.UpdateRange(edit);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<HoaDon> GetAll()
        {
            return _Context.HoaDons.Include(x => x.GiaoCa).Include(x => x.GiaoDich).
                                    Include(x => x.KhachHang).Include(x => x.LoaiPhong).
                                    Include(x => x.Phong).Include(x => x.TaiKhoan).ToList();
        }

        public HoaDon GetHoaDon(int idHoaDon)
        {
            return  _Context.HoaDons.Find(idHoaDon);
        }

        public (List<HoaDon> hoaDons, int pages, int page) Paging(int page)
        {
                int size = 10;
                int totalHoaDon = _Context.HoaDons.Count();
                int pages = (int)Math.Ceiling((double)totalHoaDon / size);
                var hoadons = _Context.HoaDons.Skip((page - 1) * size).Take(size).Include(x => x.GiaoCa).Include(x => x.GiaoDich).
                                    Include(x => x.KhachHang).Include(x => x.LoaiPhong).
                                    Include(x => x.Phong).Include(x => x.TaiKhoan).ToList();
                return (hoadons, pages, page);
        }
    }
}

