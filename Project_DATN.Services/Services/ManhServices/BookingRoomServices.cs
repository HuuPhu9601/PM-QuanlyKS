using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.ManhIServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Drawing;
using QRCoder;

namespace Project_DATN.Services.Services.ManhServices
{
    public class BookingRoomServices : IBookingServices
    {
        public readonly DB_Context _Context;
        public BookingRoomServices(DB_Context context)
        {
            _Context = context;
        }

        public async Task<List<ChiTiet_HoaDon>> hienThiDichVuSuDung()
        {
            var dichVu = await _Context.ChiTietHoaDons.Include(x => x.DichVu).ToListAsync();
            return dichVu;
        }

        public void hienThiHoaDon()
        {
            var hoaDon = (from hd in _Context.HoaDons
                         join kh in _Context.KhachHangs on hd.ID_KhachHang equals kh.ID
                         join cthd in _Context.ChiTietHoaDons on hd.ID equals cthd.ID_HoaDon
                         join dichvu in _Context.DichVus on cthd.ID_DichVu equals dichvu.ID
                         join nv in _Context.TaiKhoans on hd.ID_TaiKhoan equals nv.ID
                         join phong in _Context.Phongs on hd.ID_Phong equals phong.ID
                         join loaiPhong in _Context.LoaiPhongs on hd.ID_LoaiPhong equals loaiPhong.ID
                         select new
                         {
                             kh.hoTenKH,
                             nv.tenTaiKhoan,
                             phong.tenPhong,
                             loaiPhong.tenLoaiPhong,
                             cthd.soLuongDichVu,
                             dichvu.tenDichVu,
                             dichvu.donGia,
                             hd.ngayGioLap,
                             hd.maHoaDon,
                             hd.ngayGioNhanPhong,
                             hd.ngayGioTraPhong,
                             hd.thoiGianThue,
                             hd.cocTien,
                             hd.giamGia,
                             hd.phuThu,
                             hd.tienKhachDua,
                             hd.tienTraLai,
                             hd.thueVAT
                         }).ToList();
        }

        public bool nhanPhong(HoaDon hoaDon, int idPhong)
        {
            var checkTonTaiHoaDon = _Context.HoaDons.Count();
            var checkTonTaiKhachHang = _Context.KhachHangs.Count();
            var phong = _Context.Phongs.Find(hoaDon.ID_Phong);
            if (checkTonTaiKhachHang == 0||checkTonTaiKhachHang==null)
            {
                var kh = new KhachHang(){
                hoTenKH = hoaDon.KhachHang.hoTenKH,
                CCCD = hoaDon.KhachHang.CCCD,
                diaChi = hoaDon.KhachHang.diaChi,
                email = hoaDon.KhachHang.email,
                gioiTinh = hoaDon.KhachHang.gioiTinh,
                quocTich = hoaDon.KhachHang.quocTich,
                soDienThoai = hoaDon.KhachHang.soDienThoai,
                maKH = "KH001"
            };
                _Context.KhachHangs.Add(kh);
                _Context.SaveChanges();
            }

            
            else
            {

                var idKh = _Context.KhachHangs.Max(x => x.ID);
                var kh = new KhachHang()
                {
                    hoTenKH = hoaDon.KhachHang.hoTenKH,
                    CCCD = hoaDon.KhachHang.CCCD,
                    diaChi = hoaDon.KhachHang.diaChi,
                    email = hoaDon.KhachHang.email,
                    gioiTinh = hoaDon.KhachHang.gioiTinh,
                    quocTich = hoaDon.KhachHang.quocTich,
                    soDienThoai = hoaDon.KhachHang.soDienThoai,
                    maKH = "KH00" + (idKh + 1).ToString()
                };
                _Context.KhachHangs.Add(kh);
                _Context.SaveChanges();
            }
            if (checkTonTaiHoaDon == 0||checkTonTaiHoaDon==null)
                {
                var idKh = _Context.KhachHangs.Max(x => x.ID);
                var hd = new HoaDon()
                    {
                        ID_Phong = idPhong,
                        ID_TaiKhoan = hoaDon.ID_TaiKhoan,
                        ID_KhachHang = idKh,
                        ID_GiaoDich = 1,
                        ID_LoaiPhong = phong.ID_LoaiPhong,
                        ID_GiaoCa = hoaDon.ID_GiaoCa,
                        maHoaDon = "HĐ001",
                        ngayGioLap = DateTime.Now,
                        ngayGioNhanPhong = DateTime.Now,
                        fields1 = hoaDon.fields1,
                        cocTien = hoaDon.cocTien,
                        ghiChu = hoaDon.ghiChu,
                        trangThai = "Chưa Thanh Toán"
                    };
                    phong.trangThai = "Có Người";
                    _Context.Phongs.Update(phong);
                    _Context.HoaDons.Add(hd);
                _Context.SaveChanges();
                return true;
                }
                else
                {
                var idHoaDon = _Context.HoaDons.Max(x => x.ID);
                var idKh = _Context.KhachHangs.Max(x => x.ID);
                var hd = new HoaDon()
                {
                    ID_Phong = idPhong,
                    ID_TaiKhoan = hoaDon.ID_TaiKhoan,
                    ID_KhachHang = idKh,
                    ID_GiaoDich = 1,
                    ID_LoaiPhong = phong.ID_LoaiPhong,
                    ID_GiaoCa = hoaDon.ID_GiaoCa,
                    maHoaDon = "HĐ00" + (idHoaDon + 1).ToString(),
                    ngayGioLap = DateTime.Now,
                    ngayGioNhanPhong = DateTime.Now,
                    cocTien = hoaDon.cocTien,
                    fields1 = hoaDon.fields1,
                    ghiChu = hoaDon.ghiChu,
                    trangThai = "Chưa Thanh Toán"
                };
                phong.trangThai = "Có Người";
                _Context.Phongs.Update(phong);
                _Context.HoaDons.Add(hd);
                _Context.SaveChanges();
                return true;
            }
        }
        public bool traPhong(HoaDon hoaDon)
        {
            var edit = _Context.HoaDons.FirstOrDefault(x => x.ID == hoaDon.ID);
            if (hoaDon != null)
            {
                edit.ngayGioTraPhong = DateTime.Now;
                edit.thoiGianThue = hoaDon.ngayGioTraPhong.Subtract(edit.ngayGioNhanPhong).ToString();
                _Context.HoaDons.Update(edit);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool thanhToanHoaDon(HoaDon hoaDon)
        {
            var edit = _Context.HoaDons.FirstOrDefault(x => x.ID == hoaDon.ID);
            if (hoaDon != null)
            {
                edit.chietKhau = hoaDon.chietKhau;
                edit.phuThu = hoaDon.phuThu;
                edit.giamGia = hoaDon.giamGia;
                edit.giamTru = hoaDon.giamTru;
                edit.thueVAT = hoaDon.thueVAT;
                edit.tienKhachDua = hoaDon.tienKhachDua;
                edit.tienTraLai = hoaDon.tienTraLai;
                edit.ghiChu = hoaDon.ghiChu;
                edit.trangThai = "Đã Thanh Toán";
                var phong = _Context.Phongs.Find(hoaDon.ID_Phong);
                phong.trangThai = "Trống";
                _Context.Phongs.Update(phong);
                _Context.HoaDons.Update(edit);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<int> themDichVuSuDung(ChiTiet_HoaDon chiTiet_Hoa, int idPhong)
        {
            var hoaDon = _Context.HoaDons.Where(x => x.ID_Phong == idPhong).Single().ID;
            var addDichVu = new ChiTiet_HoaDon()
            {
                 soLuongDichVu = chiTiet_Hoa.soLuongDichVu,
                 ID_DichVu = chiTiet_Hoa.ID_DichVu,
                 ID_HoaDon = hoaDon,
                  ghiChu = chiTiet_Hoa.ghiChu
            };
            if (_Context.ChiTietHoaDons.Where(x => x.ID_HoaDon == chiTiet_Hoa.ID_HoaDon).Any(o => o.ID_DichVu == chiTiet_Hoa.ID_DichVu))
            {
                var dv = _Context.ChiTietHoaDons.Where(x => x.ID_HoaDon == chiTiet_Hoa.ID_HoaDon).FirstOrDefault();
                dv.soLuongDichVu += chiTiet_Hoa.soLuongDichVu;
                _Context.ChiTietHoaDons.Update(dv);
              return await  _Context.SaveChangesAsync();
            }
            else
            {
                _Context.ChiTietHoaDons.Add(addDichVu);
                return await _Context.SaveChangesAsync();
            }
        }

        public async Task<int> updateDichVuSuDung(ChiTiet_HoaDon chiTiet_Hoa, int soLuong)
        {
            var dv = _Context.ChiTietHoaDons.Where(x => x.ID_HoaDon == chiTiet_Hoa.ID_HoaDon).FirstOrDefault();
            dv.soLuongDichVu += soLuong;
            _Context.ChiTietHoaDons.Update(dv);
            return await _Context.SaveChangesAsync();
        }

        

        public async Task<int> xoaDichVuSuDung(int id)
        {
            var xoaDichVu = _Context.ChiTietHoaDons.Find(id);
            _Context.ChiTietHoaDons.Remove(xoaDichVu);
            return await _Context.SaveChangesAsync();
        }

        public bool ChuyenPhong(HoaDon hoaDon,int idPhongchuyen)
        {
            var chuyenPhong = _Context.HoaDons.FirstOrDefault(x => x.ID == hoaDon.ID);
            var capNhatTrangThaiPhong = _Context.HoaDons.FirstOrDefault(x => x.ID_Phong == chuyenPhong.ID_Phong).ID_Phong;
            if (chuyenPhong!=null)
            {
               
                var phongTrong = _Context.Phongs.FirstOrDefault(x => x.ID == capNhatTrangThaiPhong);
                phongTrong.trangThai = "Trống";
                _Context.Phongs.Update(phongTrong);
                _Context.SaveChanges();
                var capNhatPhongChuyenDen = _Context.Phongs.FirstOrDefault(x => x.ID == idPhongchuyen);
                capNhatPhongChuyenDen.trangThai = "Có Người";
                _Context.Phongs.Update(capNhatPhongChuyenDen);
                chuyenPhong.ID_Phong = idPhongchuyen;
                _Context.HoaDons.Update(chuyenPhong);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
