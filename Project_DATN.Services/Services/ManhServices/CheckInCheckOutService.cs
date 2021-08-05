using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DATN.Services.Services.ManhServices
{
    public class CheckInCheckOutService : ICheckInCheckOutService
    {
        public readonly DB_Context _Context;
        public CheckInCheckOutService(DB_Context Context)
        {
            _Context = Context;
        }
        public bool AddDichVu(ChiTiet_HoaDon cthd)
        {
            
            if(_Context.ChiTietHoaDons.Where(x=>x.ID_HoaDon==cthd.ID_HoaDon).Any(o=>o.ID_DichVu==cthd.ID_DichVu))
            {
                var dv = _Context.ChiTietHoaDons.Where(x => x.ID_HoaDon == cthd.ID_HoaDon).FirstOrDefault();
                dv.soLuongDichVu += cthd.soLuongDichVu;
                _Context.ChiTietHoaDons.Update(dv);
                _Context.SaveChanges();
                return true;
            }
            else {
            var dichVu = new ChiTiet_HoaDon()
            {
                ID_DichVu = cthd.ID_DichVu,
                ID_HoaDon = cthd.ID_HoaDon,
                soLuongDichVu = cthd.soLuongDichVu
            };
            _Context.ChiTietHoaDons.Add(dichVu);
            _Context.SaveChanges();
            return true;
            }
        }
       
        public bool CheckIn(HoaDon hd,int idPhong)
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
                maKH = "KH0" + (idKh + 1).ToString()
            };
            if (hd != null)
            {
                var phong = _Context.Phongs.Find(hd.ID_Phong);
                var hoaDon = new HoaDon()
                {

                    ID_Phong = idPhong,
                    ID_TaiKhoan = hd.ID_TaiKhoan,
                    ID_KhachHang = idKh,
                    ID_GiaoDich = 1,
                    ID_LoaiPhong = phong.ID_LoaiPhong,
                    ID_GiaoCa = hd.ID_GiaoCa,
                    maHoaDon = "HĐ0" + (idHoaDon + 1).ToString(),
                    ngayGioLap = DateTime.Now,
                    ngayGioNhanPhong = DateTime.Now,
                    fields1 = hd.fields1,
                    cocTien = hd.cocTien,
                    ghiChu = hd.ghiChu,
                   trangThai = "Chưa thanh toán"
            };

                phong.trangThai = "Có người";
                _Context.Phongs.Update(phong);
                _Context.KhachHangs.Add(kh);
                _Context.HoaDons.Add(hoaDon);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckOut(HoaDon hd)
        {
            var edit = _Context.HoaDons.FirstOrDefault(x => x.ID == hd.ID);
            if (hd != null)
            {
                edit.chietKhau = hd.chietKhau;
                edit.phuThu = hd.phuThu;
                edit.giamGia = hd.giamGia;
                edit.giamTru = hd.giamTru;
                edit.thueVAT = hd.thueVAT;
                edit.tienKhachDua = hd.tienKhachDua;
                edit.tienTraLai = hd.tienTraLai;
                edit.ghiChu = hd.ghiChu;
                edit.trangThai = "Đã thanh toán";
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
        
        public static DateTime Substract(DateTime now, int hours, int minutes, int seconds)
        {
            TimeSpan T1 = new TimeSpan(hours, minutes, seconds);
            return now.Subtract(T1);
        }
        public bool UpdateThoiGianTraPhong(HoaDon hd)
        {
            var edit = _Context.HoaDons.FirstOrDefault(x => x.ID == hd.ID);
            if (hd != null)
            {
                edit.ngayGioTraPhong = DateTime.Now;
                edit.thoiGianThue = hd.ngayGioTraPhong.Subtract(edit.ngayGioNhanPhong).ToString();
                _Context.HoaDons.UpdateRange(edit);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<int> ThuePhong(KhachHang khach,int idPhong)
        {

            var updateTrangThaiPhong =  _Context.Phongs.Find(idPhong);
            updateTrangThaiPhong.trangThai = "Có người";
            _Context.Phongs.Update(updateTrangThaiPhong);
            _Context.SaveChanges();
            var idKh = _Context.KhachHangs.Max(x => x.ID);
            var khachHang = new KhachHang()
            {
                hoTenKH = khach.hoTenKH,
                CCCD = khach.CCCD,
                diaChi = khach.diaChi,
                email = khach.email,
                gioiTinh = khach.gioiTinh,
                quocTich = khach.quocTich,
                soDienThoai = khach.soDienThoai,
                maKH = "KH0" + (idKh + 1).ToString(),
                trangThai = DateTime.Now.ToString()
            };
            _Context.KhachHangs.Add(khachHang);
            return await _Context.SaveChangesAsync();
        }
    }
}
