using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Data.EF.Entities.Enums;

namespace Project_DATN.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaiKhoan_NganHang>().HasData(
                new TaiKhoan_NganHang() { ID = 1, hoTenChuTKNH = "Vũ Văn Dương", soTaiKhoan = "46610001046312", tenNganHang = "Ngân hàng Thương mại cổ phần Đầu tư và Phát triển Việt Nam BIDV", tenChiNhanh = "BIDV Hưng Yên", diaChiCN = "BIDV Hưng Yên, Số 240 Nguyễn Văn Linh, P. Hiền Nam, Hưng Yên, 160000", ghiChu = "No content", trangThai = "Active" },
                new TaiKhoan_NganHang() { ID = 2, hoTenChuTKNH = "Nguyễn Ngọc Nhung", soTaiKhoan = "46610001046386", tenNganHang = "Ngân hàng Thương mại Cổ phần Quốc tế Việt Nam VIB", tenChiNhanh = "VIB Hưng Yên", diaChiCN = " 304 Nguyễn Văn Linh, P. Hiền Nam, Hưng Yên", ghiChu = "No content", trangThai = "Active" },
                new TaiKhoan_NganHang() { ID = 3, hoTenChuTKNH = "Trần Khánh Trang", soTaiKhoan = "46610001046388", tenNganHang = "Ngân hàng thương mại cổ phần Ngoại thương Việt Nam VCB", tenChiNhanh = "VCB Hưng Yên", diaChiCN = " 186 Chu Mạnh Trinh, P. Hiền Nam, Hưng Yên", ghiChu = "No content", trangThai = "Active" }
            );

            modelBuilder.Entity<Tinh_ThanhPho>().HasData(
                new Tinh_ThanhPho() { ID = 1, tenTinh = "Hưng Yên" },
                new Tinh_ThanhPho() { ID = 2, tenTinh = "Đà Lạt" },
                new Tinh_ThanhPho() { ID = 3, tenTinh = "Hà Nội" }
               );

            modelBuilder.Entity<Quan_Huyen>().HasData(
                new Quan_Huyen() { ID = 1, tenQuan_Huyen = "Yên Mỹ" },
                new Quan_Huyen() { ID = 2, tenQuan_Huyen = "Bảo Lộc" },
                new Quan_Huyen() { ID = 3, tenQuan_Huyen = "Ba Đình" }
               );

            modelBuilder.Entity<LoaiDichVu>().HasData(
                new LoaiDichVu() { ID = 1, tenLoaiDichVu = "Đồ ăn", moTa = "Gọi đồ ăn", trangThai = "Active" },
                new LoaiDichVu() { ID = 2, tenLoaiDichVu = "Đồ uống", moTa = "Gọi đồ uống", trangThai = "Active" },
                new LoaiDichVu() { ID = 3, tenLoaiDichVu = "Giặt là", moTa = "Thuê ngoài", trangThai = "Active" }
            );

            modelBuilder.Entity<DichVu>().HasData(
                new DichVu() { ID = 1, ID_LoaiDichVu = 1, tenDichVu = "Gọi cơm gà", moTa = "Cơm gà ngon", trangThai = "Active" },
                new DichVu() { ID = 2, ID_LoaiDichVu = 2, tenDichVu = "Coca-Cola", moTa = "Nước ngọt có gas", trangThai = "Active" },
                new DichVu() { ID = 3, ID_LoaiDichVu = 3, tenDichVu = "Giặt ủi", moTa = "Giặt khô", trangThai = "Active" }
            );

            //Insert Datetime format: YYMMDD hh:mm:ss
            modelBuilder.Entity<GiaoDich>().HasData(
                new GiaoDich() { ID = 1, loaiHinhThucThanhToan = "Thẻ ngân hàng", ngayGioThanhToan = (DateTime.Parse("2018.08.08 18:28:38")) },
                new GiaoDich() { ID = 2, loaiHinhThucThanhToan = "Tiền mặt", ngayGioThanhToan = (DateTime.Parse("2016/06/06 16:26:36")) },
                new GiaoDich() { ID = 3, loaiHinhThucThanhToan = "Tiền mặt", ngayGioThanhToan = (DateTime.Parse("2019/09/09 19:29:39")) }
            );

            modelBuilder.Entity<LoaiPhong>().HasData(
                new LoaiPhong() { ID = 1, tenLoaiPhong = "VIP", donGiaTheoGio = 600000, donGiaTheoNgay = 6000000, donGiaQuaDem = 5555555, soNguoi = 5, ghiChu = "Phòng Luxury có đầy đủ tiện nghi, được phép mang theo thú cưng", trangThai = "Active" },
                new LoaiPhong() { ID = 2, tenLoaiPhong = "Connecting room", donGiaTheoGio = 8000000, donGiaTheoNgay = 50000000, donGiaQuaDem = 450000000, soNguoi = 20, ghiChu = "Phòng dùng cho hộ gia đình/ group, được phép mang theo thú cưng", trangThai = "Active" },
                new LoaiPhong() { ID = 3, tenLoaiPhong = "Standard", donGiaTheoGio = 200000, donGiaTheoNgay = 1000000, donGiaQuaDem = 888888, soNguoi = 5, ghiChu = "Phòng tiêu chuẩn", trangThai = "Active" }
                    );

            modelBuilder.Entity<KhachHang>().HasData(
                new KhachHang() { ID = 1, maKH = "KH001", hoTenKH = "Nguyễn Hữu Phú", email = "daikaphucu@gmail.com", gioiTinh = "Nam", soDienThoai = "0988882001", CCCD = "033001002001", diaChi = "Phù Cừ - Hưng Yên", quocTich = "Việt Nam" },
                new KhachHang() { ID = 2, maKH = "KH002", hoTenKH = "Phạm Quốc Việt", email = "daigiayenbai@gmail.com", gioiTinh = "Nam", soDienThoai = "0988682001", CCCD = "033001012001", diaChi = "Yên Bái", quocTich = "Việt Nam" },
                new KhachHang() { ID = 3, maKH = "KH003", hoTenKH = "Lương Đức Mạnh", email = "daikayenbai@gmail.com", gioiTinh = "Nam", soDienThoai = "0986862001", CCCD = "033001022001", diaChi = "Yên Bái", quocTich = "Việt Nam" }
            );

            modelBuilder.Entity<DatPhong>().HasData(
                new DatPhong() { ID = 1, ID_KhachHang = 1, ID_LoaiPhong = 1, maDatPhong = "DP001", ngayGioDat = (DateTime.Parse("2021.08.08 18:09:08 ")), thoiGianLuuTru = "3 ngày 2 đêm", soLuongKhach = 10, soLuongPhongDat = 2, thuCung = "Chó chihuahua", ghiChu = "Phòng Luxury có mang theo thú cưng", trangThai = "Đã đặt phòng" },
                new DatPhong() { ID = 2, ID_KhachHang = 2, ID_LoaiPhong = 2, maDatPhong = "DP002", ngayGioDat = (DateTime.Parse("2021.05.18 18:09:08 ")), thoiGianLuuTru = "1 tuần", soLuongKhach = 10, soLuongPhongDat = 2, ghiChu = "Phòng tiêu chuẩn", trangThai = "Đã đặt phòng" },
                new DatPhong() { ID = 3, ID_KhachHang = 3, ID_LoaiPhong = 3, maDatPhong = "DP003", ngayGioDat = (DateTime.Parse("2021.08.18 18:09:08 ")), thoiGianLuuTru = "2 giờ", soLuongKhach = 2, soLuongPhongDat = 1, ghiChu = "Connecting room", trangThai = "Chưa xác nhận" }
            );

            modelBuilder.Entity<CoSo>().HasData(
                new CoSo() { ID = 1, ID_TK_NH = 1, ID_Tinh_TP = 1, ID_Quan_Huyen = 1, maCoSo = "CS001", tenCoSo = "An Nhiên Luxury Hotel", hoTenNguoiDaiDien = "Vũ Văn Dương", maSoThue = "8888888888", soDienThoai = "0989888888", email = "vuduong99df@gmail.com", ghiChu = "Vui lòng khách đến vừa lòng khách đi", trangThai = "Active" },
                new CoSo() { ID = 2, ID_TK_NH = 2, ID_Tinh_TP = 2, ID_Quan_Huyen = 2, maCoSo = "CS002", tenCoSo = "Diamonds Hotel", hoTenNguoiDaiDien = "Ngô Duy Long", maSoThue = "0006668686", soDienThoai = "0989989898", email = "daikathainguyen@gmail.com", ghiChu = "Lấp lánh như kim cương", trangThai = "Active" },
                new CoSo() { ID = 3, ID_TK_NH = 3, ID_Tinh_TP = 3, ID_Quan_Huyen = 3, maCoSo = "CS003", tenCoSo = "Present Duck Hotel", hoTenNguoiDaiDien = "Phạm Quốc Việt", maSoThue = "8888888888", soDienThoai = "0989888886", email = "presentduck@gmail.com", ghiChu = "Anime Hotel", trangThai = "Active" }
            );

            modelBuilder.Entity<Lau>().HasData(
                new Lau() { ID = 1, ID_CoSo = 1, tenLau = "Tầng 1", ghiChu = "Đang sửa tường, quét sơn tường các phòng", trangThai = "Inactive" },
                new Lau() { ID = 2, ID_CoSo = 2, tenLau = "Tầng 2", trangThai = "Active" },
                new Lau() { ID = 3, ID_CoSo = 3, tenLau = "Tầng 3", trangThai = "Active" }
            );

            modelBuilder.Entity<Phong>().HasData(
                new Phong() { ID = 1, ID_CoSo = 1, ID_Lau = 1, ID_LoaiPhong = 1, tenPhong = "P01", ghiChu = "Phòng đang quét sơn", trangThai = "Inactive" },
                new Phong() { ID = 2, ID_CoSo = 2, ID_Lau = 2, ID_LoaiPhong = 2, tenPhong = "P02", ghiChu = "Phòng được mang thú cưng", trangThai = "Active" },
                new Phong() { ID = 3, ID_CoSo = 3, ID_Lau = 3, ID_LoaiPhong = 3, tenPhong = "P03", ghiChu = "Phòng không được mang thú cưng ", trangThai = "Active" }
            );

            modelBuilder.Entity<LoaiPhongBan>().HasData(
                new LoaiPhongBan() { ID = 1, tenLoaiPhongBan = "Quản lý", soLuongPhongBan = 3, ghiChu = "Khách sạn An Nhiên Luxury Hotel"},
                new LoaiPhongBan() { ID = 2, tenLoaiPhongBan = "Nhân viên", soLuongPhongBan = 6, ghiChu = "Khách sạn An Nhiên Luxury Hotel" },
                new LoaiPhongBan() { ID = 3, tenLoaiPhongBan = "An ninh", soLuongPhongBan = 3, ghiChu = "Khách sạn An Nhiên Luxury Hotel" }
            );

            modelBuilder.Entity<PhongBan>().HasData(
                new PhongBan() { ID = 1, ID_LoaiPhongBan = 1, tenPhongBan = "Phòng quản trị", soLuongNhanVien = 5, ghiChu = "Phòng của quản lý khách sạn An Nhiên Luxury Hotel"},
                new PhongBan() { ID = 2, ID_LoaiPhongBan = 2, tenPhongBan = "Phòng lễ tân", soLuongNhanVien = 15, ghiChu = "Phòng của quản lý khách sạn An Nhiên Luxury Hotel"},
                new PhongBan() { ID = 3, ID_LoaiPhongBan = 3, tenPhongBan = "Phòng bảo vệ cơ sở", soLuongNhanVien = 30, ghiChu = "Phòng của quản lý khách sạn An Nhiên Luxury Hotel"}
            );

            modelBuilder.Entity<TaiKhoan>().HasData(
                new TaiKhoan() { ID = 1, ID_CoSo = 1, ID_PhongBan = 1, tenTaiKhoan = "admin2021", matKhau = "admin2021", hoTenChuTK = "Vũ Văn Dương", email = "vuduong99df@gmail.com", ngayThangNamSinh = DateTime.Parse("1999.02.27"), gioiTinh = GioiTinh.Male, soDienThoai = "0362416523", CCCD = "03309908888", diaChi = "Yên Mỹ - Hưng Yên", ngayVaoLam = DateTime.Parse("2019.09.16 08:16:28") },
                new TaiKhoan() { ID = 2, ID_CoSo = 2, ID_PhongBan = 2, tenTaiKhoan = "temp22021", matKhau = "temp22021", hoTenChuTK = "Phạm An Bình", email = "anbinh@gmail.com", ngayThangNamSinh = DateTime.Parse("1999.06.15"), gioiTinh = GioiTinh.Male, soDienThoai = "0986668888", CCCD = "03309908686", diaChi = "Yên Mỹ - Hưng Yên", ngayVaoLam = DateTime.Parse("2018.09.16 08:16:28"), ngayKetThucHopDong = DateTime.Parse("2021.09.16 08:06:28"),/*ghiChu = "Thái độ nhân viên không nghiêm túc"*/},
                new TaiKhoan() { ID = 3, ID_CoSo = 3, ID_PhongBan = 3, tenTaiKhoan = "temp32021", matKhau = "temp32021", hoTenChuTK = "Vũ Nhật Linh", email = "nhatlinh@gmail.com", ngayThangNamSinh = DateTime.Parse("2012.06.15"), gioiTinh = GioiTinh.Female, soDienThoai = "0988868888", CCCD = "03309906888", diaChi = "Yên Mỹ - Hưng Yên", ngayVaoLam = DateTime.Parse("2030.09.16 08:16:28") }
            );

            modelBuilder.Entity<ChucVu>().HasData(
                new ChucVu() { ID = 1, ID_PhongBan = 1, ID_TaiKhoan = 1, tenChucVu = "Quản lý cơ sở", ngayBatDauApDung = DateTime.Parse("2021.06.15 07:18:26")},
                new ChucVu() { ID = 2, ID_PhongBan = 2, ID_TaiKhoan = 2, tenChucVu = "Nhân viên lễ tân", ngayBatDauApDung = DateTime.Parse("2021.06.15 07:18:26")},
                new ChucVu() { ID = 3, ID_PhongBan = 3, ID_TaiKhoan = 3, tenChucVu = "Quản lý chuỗi cơ sở", ngayBatDauApDung = DateTime.Parse("2021.06.15 07:18:26"), denNgay = DateTime.Parse("2021.06.15 07:18:26")}
            );

            modelBuilder.Entity<Luong>().HasData(
                new Luong() { ID = 1, ID_TaiKhoan = 1, ngayBatDauApDung = DateTime.Parse("2020.11.11 11:11:11"), donViTinhTien = "$", tienThucLinh = 10000 },
                new Luong() { ID = 2, ID_TaiKhoan = 2, ngayBatDauApDung = DateTime.Parse("2020.11.18 18:18:18"), donViTinhTien = "$", tienThucLinh = 800 },
                new Luong() { ID = 3, ID_TaiKhoan = 3, ngayBatDauApDung = DateTime.Parse("2020.11.11 11:11:11"), denNgay = DateTime.Parse("2020.11.11 06:08:18"), donViTinhTien = "$", tienThucLinh = 600 }
            );

            modelBuilder.Entity<QuyenHan>().HasData(
                new QuyenHan() { ID = 1, tenQuyenHan = "Quyền chủ cơ sở", moTa = "Toàn quyền hệ thống", trangThai = TrangThai.HoatDong },
                new QuyenHan() { ID = 2, tenQuyenHan = "Quyền lễ tân", moTa = "Check-in và check out", trangThai = TrangThai.HoatDong },
                new QuyenHan() { ID = 3, tenQuyenHan = "Quyền quản lý cơ sở ", moTa = "Toàn quyền quản lý trong một cơ sở", trangThai = TrangThai.HoatDong }
            );

            modelBuilder.Entity<ChiTiet_QuyenHan>().HasData(
                new ChiTiet_QuyenHan() { ID = 1, ID_QuyenHan = 1, maHanhDong = "ALL", kiemTraHanhDong = "Đã thực hiện", moTa = "Toàn quyền CRUD" },//maHanhDong = ALL = Toàn quyền CRUD
                new ChiTiet_QuyenHan() { ID = 2, ID_QuyenHan = 2, maHanhDong = "EDIT", kiemTraHanhDong = "Đã thực hiện", moTa = "Chỉ được sửa" },//maHanhDong = EDIT = chỉ được sửa
                new ChiTiet_QuyenHan() { ID = 3, ID_QuyenHan = 3, maHanhDong = "DELETE", kiemTraHanhDong = "Chưa được xoá", moTa = "Chỉ được xoá" }//maHanhDong = DELETE = chỉ được xoá
            );

            modelBuilder.Entity<TaiKhoan_QuyenHan>().HasData(
                new TaiKhoan_QuyenHan() { ID = 1, ID_QuyenHan = 1, ID_TaiKhoan = 1, maSuDung = "SUDUNG01" }, //maSudung: đúng mã mới cho sd, tương tự như key/ lincensed
                new TaiKhoan_QuyenHan() { ID = 2, ID_QuyenHan = 2, ID_TaiKhoan = 2, maSuDung = "SUDUNG01" },
                new TaiKhoan_QuyenHan() { ID = 3, ID_QuyenHan = 3, ID_TaiKhoan = 3, maSuDung = "SUDUNG01" }
            );

            modelBuilder.Entity<GiaoCa>().HasData(
                new GiaoCa() { ID = 1, ID_TaiKhoan = 1, caLam = "Ca sáng", thoiDiemGiaoCa = DateTime.Parse("2021.06.20 16:28:38"), tongTienDauCa = 10000000, tongTienChenh = 10000000, soLuongHoaDon = 10, ghiChu = "10 hoá đơn phòng Standard" },
                new GiaoCa() { ID = 2, ID_TaiKhoan = 2, caLam = "Ca chiều", thoiDiemGiaoCa = DateTime.Parse("2021.06.21 16:28:38"), tongTienDauCa = 20000000, tongTienChenh = 10000000, soLuongHoaDon = 5, ghiChu = "5 hoá đơn phòng VIP" },
                new GiaoCa() { ID = 3, ID_TaiKhoan = 3, caLam = "Ca gãy", thoiDiemGiaoCa = DateTime.Parse("2021.06.22 16:28:38"), tongTienDauCa = 30000000, tongTienChenh = 5000000, soLuongHoaDon = 5, ghiChu = "5 hoá đơn phòng Standard" }
            );

            modelBuilder.Entity<HoaDon>().HasData(
                new HoaDon() { ID = 1, ID_LoaiPhong = 1, ID_TaiKhoan = 1, ID_GiaoCa = 1, ID_GiaoDich = 1, ID_KhachHang = 1, ID_Phong = 1, maHoaDon = "HĐ0001", ngayGioLap = DateTime.Parse("2021.11.15 18:28:38"), ngayGioNhanPhong = DateTime.Parse("2021.11.16 12:00:00"), ngayGioTraPhong = DateTime.Parse("2021.11.23 12:00:00"), thoiGianThue = " 1 tuần 1 đêm", tienKhachDua = 8000000, tienTraLai = 0, giamTru = 0, cocTien = 0, phuThu = 800000, thueVAT = 888000, chietKhau = 0, giamGia = 1000000, trangThai = "Đã thanh toán" },
                new HoaDon() { ID = 2, ID_LoaiPhong = 2, ID_TaiKhoan = 2, ID_GiaoCa = 2, ID_GiaoDich = 2, ID_KhachHang = 2, ID_Phong = 2, maHoaDon = "HĐ0002", ngayGioLap = DateTime.Parse("2021.11.16 19:29:39"), ngayGioNhanPhong = DateTime.Parse("2021.11.17 12:00:00"), ngayGioTraPhong = DateTime.Parse("2021.11.23 12:00:00"), thoiGianThue = " 1 tuần 1 đêm", tienKhachDua = 8000000, tienTraLai = 0, giamTru = 0, cocTien = 0, phuThu = 800000, thueVAT = 888000, chietKhau = 0, giamGia = 1000000, trangThai = "Đã thanh toán" },
                new HoaDon() { ID = 3, ID_LoaiPhong = 3, ID_TaiKhoan = 3, ID_GiaoCa = 3, ID_GiaoDich = 3, ID_KhachHang = 3, ID_Phong = 3, maHoaDon = "HĐ0003", ngayGioLap = DateTime.Parse("2021.11.18 20:20:20"), ngayGioNhanPhong = DateTime.Parse("2021.11.20 12:00:00"), ngayGioTraPhong = DateTime.Parse("2021.11.24 12:00:00"), thoiGianThue = " 1 tuần 1 đêm", tienKhachDua = 8000000, tienTraLai = 0, giamTru = 0, cocTien = 0, phuThu = 800000, thueVAT = 888000, chietKhau = 0, giamGia = 1000000, trangThai = "Đã thanh toán" }
            );

            modelBuilder.Entity<ChiTiet_HoaDon>().HasData(
                new ChiTiet_HoaDon() { ID = 1, ID_HoaDon = 1, ID_DichVu = 1, soLuongDichVu = 10, trangThai = "Đang hoạt động" },
                new ChiTiet_HoaDon() { ID = 2, ID_HoaDon = 2, ID_DichVu = 2, soLuongDichVu = 20, trangThai = "Đang hoạt động" },
                new ChiTiet_HoaDon() { ID = 3, ID_HoaDon = 3, ID_DichVu = 3, soLuongDichVu = 10, trangThai = "Ngừng hoạt động" }
            );

        }
    }
}
