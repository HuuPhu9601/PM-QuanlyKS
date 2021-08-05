using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_DATN.Data.Migrations
{
    public partial class HotelManagementMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiaoDich",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loaiHinhThucThanhToan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ngayGioThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoDich", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maKH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    hoTenKH = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    email = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    gioiTinh = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    soDienThoai = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CCCD = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    diaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    quocTich = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDichVu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenLoaiDichVu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    moTa = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDichVu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenLoaiPhong = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    donGiaTheoGio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    donGiaTheoNgay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    donGiaQuaDem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    soNguoi = table.Column<int>(type: "int", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhong", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhongBans",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maLoaiPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tenLoaiPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    soLuongPhongBan = table.Column<int>(type: "int", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhongBans", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Quan_Huyen",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenQuan_Huyen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quan_Huyen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QuyenHan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenQuyenHan = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    moTa = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    trangThai = table.Column<int>(type: "int", nullable: false),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenHan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan_NganHang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoTenChuTKNH = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    soTaiKhoan = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    tenNganHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    tenChiNhanh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    diaChiCN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan_NganHang", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tinh_ThanhPho",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenTinh = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tinh_ThanhPho", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DichVu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_LoaiDichVu = table.Column<int>(type: "int", nullable: false),
                    tenDichVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    donViTinh = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    donGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    donViTien = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    moTa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DichVu_LoaiDichVu_ID_LoaiDichVu",
                        column: x => x.ID_LoaiDichVu,
                        principalTable: "LoaiDichVu",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DatPhong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_KhachHang = table.Column<int>(type: "int", nullable: false),
                    ID_LoaiPhong = table.Column<int>(type: "int", nullable: false),
                    maDatPhong = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ngayGioDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    thoiGianLuuTru = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    soLuongKhach = table.Column<int>(type: "int", nullable: false),
                    soLuongPhongDat = table.Column<int>(type: "int", nullable: false),
                    thuCung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatPhong", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DatPhong_KhachHang_ID_KhachHang",
                        column: x => x.ID_KhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DatPhong_LoaiPhong_ID_LoaiPhong",
                        column: x => x.ID_LoaiPhong,
                        principalTable: "LoaiPhong",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_LoaiPhongBan = table.Column<int>(type: "int", nullable: false),
                    tenPhongBan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    soLuongPhongBan = table.Column<int>(type: "int", nullable: false),
                    soLuongNhanVien = table.Column<int>(type: "int", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    trangThai = table.Column<int>(type: "int", nullable: false),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhongBan_LoaiPhongBans_ID_LoaiPhongBan",
                        column: x => x.ID_LoaiPhongBan,
                        principalTable: "LoaiPhongBans",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ChiTiet_QuyenHan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_QuyenHan = table.Column<int>(type: "int", nullable: false),
                    maHanhDong = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    kiemTraHanhDong = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    moTa = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTiet_QuyenHan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChiTiet_QuyenHan_QuyenHan_ID_QuyenHan",
                        column: x => x.ID_QuyenHan,
                        principalTable: "QuyenHan",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CoSo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Tinh_TP = table.Column<int>(type: "int", nullable: false),
                    ID_Quan_Huyen = table.Column<int>(type: "int", nullable: false),
                    ID_TK_NH = table.Column<int>(type: "int", nullable: false),
                    maCoSo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    tenCoSo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    hoTenNguoiDaiDien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    maSoThue = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    soDienThoai = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    email = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoSo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CoSo_Quan_Huyen_ID_Quan_Huyen",
                        column: x => x.ID_Quan_Huyen,
                        principalTable: "Quan_Huyen",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CoSo_TaiKhoan_NganHang_ID_TK_NH",
                        column: x => x.ID_TK_NH,
                        principalTable: "TaiKhoan_NganHang",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CoSo_Tinh_ThanhPho_ID_Tinh_TP",
                        column: x => x.ID_Tinh_TP,
                        principalTable: "Tinh_ThanhPho",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Lau",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_CoSo = table.Column<int>(type: "int", nullable: false),
                    tenLau = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    soLuongLau = table.Column<int>(type: "int", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lau", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lau_CoSo_ID_CoSo",
                        column: x => x.ID_CoSo,
                        principalTable: "CoSo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_CoSo = table.Column<int>(type: "int", nullable: false),
                    ID_PhongBan = table.Column<int>(type: "int", nullable: false),
                    tenTaiKhoan = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    matKhau = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    hoTenChuTK = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    ngayThangNamSinh = table.Column<DateTime>(type: "DATE", nullable: false),
                    gioiTinh = table.Column<int>(type: "int", nullable: false),
                    soDienThoai = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CCCD = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    diaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngayVaoLam = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngayKetThucHopDong = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    anhDaiDien = table.Column<string>(type: "nvarchar(886)", nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_CoSo_ID_CoSo",
                        column: x => x.ID_CoSo,
                        principalTable: "CoSo",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TaiKhoan_PhongBan_ID_PhongBan",
                        column: x => x.ID_PhongBan,
                        principalTable: "PhongBan",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_LoaiPhong = table.Column<int>(type: "int", nullable: false),
                    ID_CoSo = table.Column<int>(type: "int", nullable: false),
                    ID_Lau = table.Column<int>(type: "int", nullable: false),
                    tenPhong = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    soLuongPhong = table.Column<int>(type: "int", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Phong_CoSo_ID_CoSo",
                        column: x => x.ID_CoSo,
                        principalTable: "CoSo",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Phong_Lau_ID_Lau",
                        column: x => x.ID_Lau,
                        principalTable: "Lau",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Phong_LoaiPhong_ID_LoaiPhong",
                        column: x => x.ID_LoaiPhong,
                        principalTable: "LoaiPhong",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_TaiKhoan = table.Column<int>(type: "int", nullable: false),
                    ID_PhongBan = table.Column<int>(type: "int", nullable: false),
                    tenChucVu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ngayBatDauApDung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    denNgay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    trangThai = table.Column<int>(type: "int", nullable: false),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChucVu_PhongBan_ID_PhongBan",
                        column: x => x.ID_PhongBan,
                        principalTable: "PhongBan",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ChucVu_TaiKhoan_ID_TaiKhoan",
                        column: x => x.ID_TaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GiaoCa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_TaiKhoan = table.Column<int>(type: "int", nullable: false),
                    caLam = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    thoiDiemGiaoCa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tongTienDauCa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tongTienChenh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    soLuongHoaDon = table.Column<int>(type: "int", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoCa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GiaoCa_TaiKhoan_ID_TaiKhoan",
                        column: x => x.ID_TaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Luong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_TaiKhoan = table.Column<int>(type: "int", nullable: false),
                    ngayBatDauApDung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    denNgay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    tienThucLinh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    donViTinhTien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luong", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Luong_TaiKhoan_ID_TaiKhoan",
                        column: x => x.ID_TaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan_QuyenHan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_QuyenHan = table.Column<int>(type: "int", nullable: false),
                    ID_TaiKhoan = table.Column<int>(type: "int", nullable: false),
                    maSuDung = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    moTa = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan_QuyenHan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_QuyenHan_QuyenHan_ID_QuyenHan",
                        column: x => x.ID_QuyenHan,
                        principalTable: "QuyenHan",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TaiKhoan_QuyenHan_TaiKhoan_ID_QuyenHan",
                        column: x => x.ID_QuyenHan,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_KhachHang = table.Column<int>(type: "int", nullable: false),
                    ID_TaiKhoan = table.Column<int>(type: "int", nullable: false),
                    ID_GiaoDich = table.Column<int>(type: "int", nullable: false),
                    ID_LoaiPhong = table.Column<int>(type: "int", nullable: false),
                    ID_Phong = table.Column<int>(type: "int", nullable: false),
                    ID_GiaoCa = table.Column<int>(type: "int", nullable: false),
                    maHoaDon = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ngayGioLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngayGioNhanPhong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngayGioTraPhong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    thoiGianThue = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    tienKhachDua = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tienTraLai = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    giamTru = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cocTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    phuThu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    thueVAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    chietKhau = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    giamGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatPhongID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HoaDon_DatPhong_DatPhongID",
                        column: x => x.DatPhongID,
                        principalTable: "DatPhong",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDon_GiaoCa_ID_GiaoCa",
                        column: x => x.ID_GiaoCa,
                        principalTable: "GiaoCa",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_HoaDon_GiaoDich_ID_GiaoDich",
                        column: x => x.ID_GiaoDich,
                        principalTable: "GiaoDich",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_ID_KhachHang",
                        column: x => x.ID_KhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_HoaDon_LoaiPhong_ID_LoaiPhong",
                        column: x => x.ID_LoaiPhong,
                        principalTable: "LoaiPhong",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_HoaDon_Phong_ID_Phong",
                        column: x => x.ID_Phong,
                        principalTable: "Phong",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_HoaDon_TaiKhoan_ID_TaiKhoan",
                        column: x => x.ID_TaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ChiTiet_HoaDon",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_HoaDon = table.Column<int>(type: "int", nullable: false),
                    ID_DichVu = table.Column<int>(type: "int", nullable: false),
                    soLuongDichVu = table.Column<int>(type: "int", nullable: false),
                    ghiChu = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    fields1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fields5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTiet_HoaDon", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChiTiet_HoaDon_DichVu_ID_DichVu",
                        column: x => x.ID_DichVu,
                        principalTable: "DichVu",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ChiTiet_HoaDon_HoaDon_ID_HoaDon",
                        column: x => x.ID_HoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "GiaoDich",
                columns: new[] { "ID", "fields1", "fields2", "fields3", "fields4", "fields5", "loaiHinhThucThanhToan", "ngayGioThanhToan", "trangThai" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, "Thẻ ngân hàng", new DateTime(2018, 8, 8, 18, 28, 38, 0, DateTimeKind.Unspecified), null },
                    { 2, null, null, null, null, null, "Tiền mặt", new DateTime(2016, 6, 6, 16, 26, 36, 0, DateTimeKind.Unspecified), null },
                    { 3, null, null, null, null, null, "Tiền mặt", new DateTime(2019, 9, 9, 19, 29, 39, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "KhachHang",
                columns: new[] { "ID", "CCCD", "diaChi", "email", "fields1", "fields2", "fields3", "fields4", "fields5", "gioiTinh", "hoTenKH", "maKH", "quocTich", "soDienThoai", "trangThai" },
                values: new object[,]
                {
                    { 1, "033001002001", "Phù Cừ - Hưng Yên", "daikaphucu@gmail.com", null, null, null, null, null, "Nam", "Nguyễn Hữu Phú", "KH001", "Việt Nam", "0988882001", null },
                    { 2, "033001012001", "Yên Bái", "daigiayenbai@gmail.com", null, null, null, null, null, "Nam", "Phạm Quốc Việt", "KH002", "Việt Nam", "0988682001", null },
                    { 3, "033001022001", "Yên Bái", "daikayenbai@gmail.com", null, null, null, null, null, "Nam", "Lương Đức Mạnh", "KH003", "Việt Nam", "0986862001", null }
                });

            migrationBuilder.InsertData(
                table: "LoaiDichVu",
                columns: new[] { "ID", "fields1", "fields2", "fields3", "fields4", "fields5", "moTa", "tenLoaiDichVu", "trangThai" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, "Gọi đồ ăn", "Đồ ăn", "Active" },
                    { 2, null, null, null, null, null, "Gọi đồ uống", "Đồ uống", "Active" },
                    { 3, null, null, null, null, null, "Thuê ngoài", "Giặt là", "Active" }
                });

            migrationBuilder.InsertData(
                table: "LoaiPhong",
                columns: new[] { "ID", "donGiaQuaDem", "donGiaTheoGio", "donGiaTheoNgay", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "soNguoi", "tenLoaiPhong", "trangThai" },
                values: new object[,]
                {
                    { 1, 5555555m, 600000m, 6000000m, null, null, null, null, null, "Phòng Luxury có đầy đủ tiện nghi, được phép mang theo thú cưng", 5, "VIP", "Active" },
                    { 2, 450000000m, 8000000m, 50000000m, null, null, null, null, null, "Phòng dùng cho hộ gia đình/ group, được phép mang theo thú cưng", 20, "Connecting room", "Active" },
                    { 3, 888888m, 200000m, 1000000m, null, null, null, null, null, "Phòng tiêu chuẩn", 5, "Standard", "Active" }
                });

            migrationBuilder.InsertData(
                table: "LoaiPhongBans",
                columns: new[] { "ID", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "maLoaiPhongBan", "soLuongPhongBan", "tenLoaiPhongBan", "trangThai" },
                values: new object[,]
                {
                    { 3, null, null, null, null, null, "Khách sạn An Nhiên Luxury Hotel", null, 3, "An ninh", null },
                    { 2, null, null, null, null, null, "Khách sạn An Nhiên Luxury Hotel", null, 6, "Nhân viên", null },
                    { 1, null, null, null, null, null, "Khách sạn An Nhiên Luxury Hotel", null, 3, "Quản lý", null }
                });

            migrationBuilder.InsertData(
                table: "Quan_Huyen",
                columns: new[] { "ID", "fields1", "fields2", "fields3", "fields4", "fields5", "tenQuan_Huyen", "trangThai" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, "Yên Mỹ", null },
                    { 2, null, null, null, null, null, "Bảo Lộc", null },
                    { 3, null, null, null, null, null, "Ba Đình", null }
                });

            migrationBuilder.InsertData(
                table: "QuyenHan",
                columns: new[] { "ID", "fields1", "fields2", "fields3", "fields4", "fields5", "moTa", "tenQuyenHan", "trangThai" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, "Toàn quyền hệ thống", "Quyền chủ cơ sở", 0 },
                    { 2, null, null, null, null, null, "Check-in và check out", "Quyền lễ tân", 0 },
                    { 3, null, null, null, null, null, "Toàn quyền quản lý trong một cơ sở", "Quyền quản lý cơ sở ", 0 }
                });

            migrationBuilder.InsertData(
                table: "TaiKhoan_NganHang",
                columns: new[] { "ID", "diaChiCN", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "hoTenChuTKNH", "soTaiKhoan", "tenChiNhanh", "tenNganHang", "trangThai" },
                values: new object[,]
                {
                    { 1, "BIDV Hưng Yên, Số 240 Nguyễn Văn Linh, P. Hiền Nam, Hưng Yên, 160000", null, null, null, null, null, "No content", "Vũ Văn Dương", "46610001046312", "BIDV Hưng Yên", "Ngân hàng Thương mại cổ phần Đầu tư và Phát triển Việt Nam BIDV", "Active" },
                    { 2, " 304 Nguyễn Văn Linh, P. Hiền Nam, Hưng Yên", null, null, null, null, null, "No content", "Nguyễn Ngọc Nhung", "46610001046386", "VIB Hưng Yên", "Ngân hàng Thương mại Cổ phần Quốc tế Việt Nam VIB", "Active" },
                    { 3, " 186 Chu Mạnh Trinh, P. Hiền Nam, Hưng Yên", null, null, null, null, null, "No content", "Trần Khánh Trang", "46610001046388", "VCB Hưng Yên", "Ngân hàng thương mại cổ phần Ngoại thương Việt Nam VCB", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Tinh_ThanhPho",
                columns: new[] { "ID", "fields1", "fields2", "fields3", "fields4", "fields5", "tenTinh", "trangThai" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, "Hưng Yên", null },
                    { 2, null, null, null, null, null, "Đà Lạt", null },
                    { 3, null, null, null, null, null, "Hà Nội", null }
                });

            migrationBuilder.InsertData(
                table: "ChiTiet_QuyenHan",
                columns: new[] { "ID", "ID_QuyenHan", "fields1", "fields2", "fields3", "fields4", "fields5", "kiemTraHanhDong", "maHanhDong", "moTa", "trangThai" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, null, null, "Đã thực hiện", "ALL", "Toàn quyền CRUD", null },
                    { 2, 2, null, null, null, null, null, "Đã thực hiện", "EDIT", "Chỉ được sửa", null },
                    { 3, 3, null, null, null, null, null, "Chưa được xoá", "DELETE", "Chỉ được xoá", null }
                });

            migrationBuilder.InsertData(
                table: "CoSo",
                columns: new[] { "ID", "ID_Quan_Huyen", "ID_TK_NH", "ID_Tinh_TP", "email", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "hoTenNguoiDaiDien", "maCoSo", "maSoThue", "soDienThoai", "tenCoSo", "trangThai" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "vuduong99df@gmail.com", null, null, null, null, null, "Vui lòng khách đến vừa lòng khách đi", "Vũ Văn Dương", "CS001", "8888888888", "0989888888", "An Nhiên Luxury Hotel", "Active" },
                    { 2, 2, 2, 2, "daikathainguyen@gmail.com", null, null, null, null, null, "Lấp lánh như kim cương", "Ngô Duy Long", "CS002", "0006668686", "0989989898", "Diamonds Hotel", "Active" },
                    { 3, 3, 3, 3, "presentduck@gmail.com", null, null, null, null, null, "Anime Hotel", "Phạm Quốc Việt", "CS003", "8888888888", "0989888886", "Present Duck Hotel", "Active" }
                });

            migrationBuilder.InsertData(
                table: "DatPhong",
                columns: new[] { "ID", "ID_KhachHang", "ID_LoaiPhong", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "maDatPhong", "ngayGioDat", "soLuongKhach", "soLuongPhongDat", "thoiGianLuuTru", "thuCung", "trangThai" },
                values: new object[,]
                {
                    { 1, 1, 1, null, null, null, null, null, "Phòng Luxury có mang theo thú cưng", "DP001", new DateTime(2021, 8, 8, 18, 9, 8, 0, DateTimeKind.Unspecified), 10, 2, "3 ngày 2 đêm", "Chó chihuahua", "Đã đặt phòng" },
                    { 2, 2, 2, null, null, null, null, null, "Phòng tiêu chuẩn", "DP002", new DateTime(2021, 5, 18, 18, 9, 8, 0, DateTimeKind.Unspecified), 10, 2, "1 tuần", null, "Đã đặt phòng" },
                    { 3, 3, 3, null, null, null, null, null, "Connecting room", "DP003", new DateTime(2021, 8, 18, 18, 9, 8, 0, DateTimeKind.Unspecified), 2, 1, "2 giờ", null, "Chưa xác nhận" }
                });

            migrationBuilder.InsertData(
                table: "DichVu",
                columns: new[] { "ID", "ID_LoaiDichVu", "donGia", "donViTien", "donViTinh", "fields1", "fields2", "fields3", "fields4", "fields5", "moTa", "tenDichVu", "trangThai" },
                values: new object[,]
                {
                    { 1, 1, 0m, null, null, null, null, null, null, null, "Cơm gà ngon", "Gọi cơm gà", "Active" },
                    { 2, 2, 0m, null, null, null, null, null, null, null, "Nước ngọt có gas", "Coca-Cola", "Active" },
                    { 3, 3, 0m, null, null, null, null, null, null, null, "Giặt khô", "Giặt ủi", "Active" }
                });

            migrationBuilder.InsertData(
                table: "PhongBan",
                columns: new[] { "ID", "ID_LoaiPhongBan", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "soLuongNhanVien", "soLuongPhongBan", "tenPhongBan", "trangThai" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, null, null, "Phòng của quản lý khách sạn An Nhiên Luxury Hotel", 5, 0, "Phòng quản trị", 0 },
                    { 2, 2, null, null, null, null, null, "Phòng của quản lý khách sạn An Nhiên Luxury Hotel", 15, 0, "Phòng lễ tân", 0 },
                    { 3, 3, null, null, null, null, null, "Phòng của quản lý khách sạn An Nhiên Luxury Hotel", 30, 0, "Phòng bảo vệ cơ sở", 0 }
                });

            migrationBuilder.InsertData(
                table: "Lau",
                columns: new[] { "ID", "ID_CoSo", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "soLuongLau", "tenLau", "trangThai" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, null, null, "Đang sửa tường, quét sơn tường các phòng", 0, "Tầng 1", "Inactive" },
                    { 2, 2, null, null, null, null, null, null, 0, "Tầng 2", "Active" },
                    { 3, 3, null, null, null, null, null, null, 0, "Tầng 3", "Active" }
                });

            migrationBuilder.InsertData(
                table: "TaiKhoan",
                columns: new[] { "ID", "CCCD", "ID_CoSo", "ID_PhongBan", "TrangThai", "anhDaiDien", "diaChi", "email", "fields1", "fields2", "fields3", "fields4", "fields5", "gioiTinh", "hoTenChuTK", "matKhau", "ngayKetThucHopDong", "ngayThangNamSinh", "ngayVaoLam", "soDienThoai", "tenTaiKhoan" },
                values: new object[,]
                {
                    { 1, "03309908888", 1, 1, 0, null, "Yên Mỹ - Hưng Yên", "vuduong99df@gmail.com", null, null, null, null, null, 0, "Vũ Văn Dương", "admin2021", null, new DateTime(1999, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 16, 8, 16, 28, 0, DateTimeKind.Unspecified), "0362416523", "admin2021" },
                    { 2, "03309908686", 2, 2, 0, null, "Yên Mỹ - Hưng Yên", "anbinh@gmail.com", null, null, null, null, null, 0, "Phạm An Bình", "temp22021", new DateTime(2021, 9, 16, 8, 6, 28, 0, DateTimeKind.Unspecified), new DateTime(1999, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 16, 8, 16, 28, 0, DateTimeKind.Unspecified), "0986668888", "temp22021" },
                    { 3, "03309906888", 3, 3, 0, null, "Yên Mỹ - Hưng Yên", "nhatlinh@gmail.com", null, null, null, null, null, 1, "Vũ Nhật Linh", "temp32021", null, new DateTime(2012, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 9, 16, 8, 16, 28, 0, DateTimeKind.Unspecified), "0988868888", "temp32021" }
                });

            migrationBuilder.InsertData(
                table: "ChucVu",
                columns: new[] { "ID", "ID_PhongBan", "ID_TaiKhoan", "denNgay", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "ngayBatDauApDung", "tenChucVu", "trangThai" },
                values: new object[,]
                {
                    { 1, 1, 1, null, null, null, null, null, null, null, new DateTime(2021, 6, 15, 7, 18, 26, 0, DateTimeKind.Unspecified), "Quản lý cơ sở", 0 },
                    { 2, 2, 2, null, null, null, null, null, null, null, new DateTime(2021, 6, 15, 7, 18, 26, 0, DateTimeKind.Unspecified), "Nhân viên lễ tân", 0 },
                    { 3, 3, 3, new DateTime(2021, 6, 15, 7, 18, 26, 0, DateTimeKind.Unspecified), null, null, null, null, null, null, new DateTime(2021, 6, 15, 7, 18, 26, 0, DateTimeKind.Unspecified), "Quản lý chuỗi cơ sở", 0 }
                });

            migrationBuilder.InsertData(
                table: "GiaoCa",
                columns: new[] { "ID", "ID_TaiKhoan", "caLam", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "soLuongHoaDon", "thoiDiemGiaoCa", "tongTienChenh", "tongTienDauCa", "trangThai" },
                values: new object[,]
                {
                    { 1, 1, "Ca sáng", null, null, null, null, null, "10 hoá đơn phòng Standard", 10, new DateTime(2021, 6, 20, 16, 28, 38, 0, DateTimeKind.Unspecified), 10000000m, 10000000m, null },
                    { 2, 2, "Ca chiều", null, null, null, null, null, "5 hoá đơn phòng VIP", 5, new DateTime(2021, 6, 21, 16, 28, 38, 0, DateTimeKind.Unspecified), 10000000m, 20000000m, null },
                    { 3, 3, "Ca gãy", null, null, null, null, null, "5 hoá đơn phòng Standard", 5, new DateTime(2021, 6, 22, 16, 28, 38, 0, DateTimeKind.Unspecified), 5000000m, 30000000m, null }
                });

            migrationBuilder.InsertData(
                table: "Luong",
                columns: new[] { "ID", "ID_TaiKhoan", "denNgay", "donViTinhTien", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "ngayBatDauApDung", "tienThucLinh", "trangThai" },
                values: new object[,]
                {
                    { 1, 1, null, "$", null, null, null, null, null, null, new DateTime(2020, 11, 11, 11, 11, 11, 0, DateTimeKind.Unspecified), 10000m, null },
                    { 2, 2, null, "$", null, null, null, null, null, null, new DateTime(2020, 11, 18, 18, 18, 18, 0, DateTimeKind.Unspecified), 800m, null },
                    { 3, 3, new DateTime(2020, 11, 11, 6, 8, 18, 0, DateTimeKind.Unspecified), "$", null, null, null, null, null, null, new DateTime(2020, 11, 11, 11, 11, 11, 0, DateTimeKind.Unspecified), 600m, null }
                });

            migrationBuilder.InsertData(
                table: "Phong",
                columns: new[] { "ID", "ID_CoSo", "ID_Lau", "ID_LoaiPhong", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "soLuongPhong", "tenPhong", "trangThai" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, null, null, null, null, null, "Phòng đang quét sơn", 0, "P01", "Inactive" },
                    { 2, 2, 2, 2, null, null, null, null, null, "Phòng được mang thú cưng", 0, "P02", "Active" },
                    { 3, 3, 3, 3, null, null, null, null, null, "Phòng không được mang thú cưng ", 0, "P03", "Active" }
                });

            migrationBuilder.InsertData(
                table: "TaiKhoan_QuyenHan",
                columns: new[] { "ID", "ID_QuyenHan", "ID_TaiKhoan", "fields1", "fields2", "fields3", "fields4", "fields5", "maSuDung", "moTa", "trangThai" },
                values: new object[,]
                {
                    { 1, 1, 1, null, null, null, null, null, "SUDUNG01", null, null },
                    { 2, 2, 2, null, null, null, null, null, "SUDUNG01", null, null },
                    { 3, 3, 3, null, null, null, null, null, "SUDUNG01", null, null }
                });

            migrationBuilder.InsertData(
                table: "HoaDon",
                columns: new[] { "ID", "DatPhongID", "ID_GiaoCa", "ID_GiaoDich", "ID_KhachHang", "ID_LoaiPhong", "ID_Phong", "ID_TaiKhoan", "chietKhau", "cocTien", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "giamGia", "giamTru", "maHoaDon", "ngayGioLap", "ngayGioNhanPhong", "ngayGioTraPhong", "phuThu", "thoiGianThue", "thueVAT", "tienKhachDua", "tienTraLai", "trangThai" },
                values: new object[] { 1, null, 1, 1, 1, 1, 1, 1, 0m, 0m, null, null, null, null, null, null, 1000000m, 0m, "HĐ0001", new DateTime(2021, 11, 15, 18, 28, 38, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), 800000m, " 1 tuần 1 đêm", 888000m, 8000000m, 0m, "Đã thanh toán" });

            migrationBuilder.InsertData(
                table: "HoaDon",
                columns: new[] { "ID", "DatPhongID", "ID_GiaoCa", "ID_GiaoDich", "ID_KhachHang", "ID_LoaiPhong", "ID_Phong", "ID_TaiKhoan", "chietKhau", "cocTien", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "giamGia", "giamTru", "maHoaDon", "ngayGioLap", "ngayGioNhanPhong", "ngayGioTraPhong", "phuThu", "thoiGianThue", "thueVAT", "tienKhachDua", "tienTraLai", "trangThai" },
                values: new object[] { 2, null, 2, 2, 2, 2, 2, 2, 0m, 0m, null, null, null, null, null, null, 1000000m, 0m, "HĐ0002", new DateTime(2021, 11, 16, 19, 29, 39, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), 800000m, " 1 tuần 1 đêm", 888000m, 8000000m, 0m, "Đã thanh toán" });

            migrationBuilder.InsertData(
                table: "HoaDon",
                columns: new[] { "ID", "DatPhongID", "ID_GiaoCa", "ID_GiaoDich", "ID_KhachHang", "ID_LoaiPhong", "ID_Phong", "ID_TaiKhoan", "chietKhau", "cocTien", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "giamGia", "giamTru", "maHoaDon", "ngayGioLap", "ngayGioNhanPhong", "ngayGioTraPhong", "phuThu", "thoiGianThue", "thueVAT", "tienKhachDua", "tienTraLai", "trangThai" },
                values: new object[] { 3, null, 3, 3, 3, 3, 3, 3, 0m, 0m, null, null, null, null, null, null, 1000000m, 0m, "HĐ0003", new DateTime(2021, 11, 18, 20, 20, 20, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 24, 12, 0, 0, 0, DateTimeKind.Unspecified), 800000m, " 1 tuần 1 đêm", 888000m, 8000000m, 0m, "Đã thanh toán" });

            migrationBuilder.InsertData(
                table: "ChiTiet_HoaDon",
                columns: new[] { "ID", "ID_DichVu", "ID_HoaDon", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "soLuongDichVu", "trangThai" },
                values: new object[] { 1, 1, 1, null, null, null, null, null, null, 10, "Đang hoạt động" });

            migrationBuilder.InsertData(
                table: "ChiTiet_HoaDon",
                columns: new[] { "ID", "ID_DichVu", "ID_HoaDon", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "soLuongDichVu", "trangThai" },
                values: new object[] { 2, 2, 2, null, null, null, null, null, null, 20, "Đang hoạt động" });

            migrationBuilder.InsertData(
                table: "ChiTiet_HoaDon",
                columns: new[] { "ID", "ID_DichVu", "ID_HoaDon", "fields1", "fields2", "fields3", "fields4", "fields5", "ghiChu", "soLuongDichVu", "trangThai" },
                values: new object[] { 3, 3, 3, null, null, null, null, null, null, 10, "Ngừng hoạt động" });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_HoaDon_ID_DichVu",
                table: "ChiTiet_HoaDon",
                column: "ID_DichVu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_HoaDon_ID_HoaDon",
                table: "ChiTiet_HoaDon",
                column: "ID_HoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_QuyenHan_ID_QuyenHan",
                table: "ChiTiet_QuyenHan",
                column: "ID_QuyenHan");

            migrationBuilder.CreateIndex(
                name: "IX_ChucVu_ID_PhongBan",
                table: "ChucVu",
                column: "ID_PhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_ChucVu_ID_TaiKhoan",
                table: "ChucVu",
                column: "ID_TaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_CoSo_ID_Quan_Huyen",
                table: "CoSo",
                column: "ID_Quan_Huyen");

            migrationBuilder.CreateIndex(
                name: "IX_CoSo_ID_Tinh_TP",
                table: "CoSo",
                column: "ID_Tinh_TP");

            migrationBuilder.CreateIndex(
                name: "IX_CoSo_ID_TK_NH",
                table: "CoSo",
                column: "ID_TK_NH");

            migrationBuilder.CreateIndex(
                name: "IX_DatPhong_ID_KhachHang",
                table: "DatPhong",
                column: "ID_KhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DatPhong_ID_LoaiPhong",
                table: "DatPhong",
                column: "ID_LoaiPhong");

            migrationBuilder.CreateIndex(
                name: "IX_DichVu_ID_LoaiDichVu",
                table: "DichVu",
                column: "ID_LoaiDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoCa_ID_TaiKhoan",
                table: "GiaoCa",
                column: "ID_TaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_DatPhongID",
                table: "HoaDon",
                column: "DatPhongID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ID_GiaoCa",
                table: "HoaDon",
                column: "ID_GiaoCa");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ID_GiaoDich",
                table: "HoaDon",
                column: "ID_GiaoDich");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ID_KhachHang",
                table: "HoaDon",
                column: "ID_KhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ID_LoaiPhong",
                table: "HoaDon",
                column: "ID_LoaiPhong");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ID_Phong",
                table: "HoaDon",
                column: "ID_Phong");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_ID_TaiKhoan",
                table: "HoaDon",
                column: "ID_TaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_Lau_ID_CoSo",
                table: "Lau",
                column: "ID_CoSo");

            migrationBuilder.CreateIndex(
                name: "IX_Luong_ID_TaiKhoan",
                table: "Luong",
                column: "ID_TaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_ID_CoSo",
                table: "Phong",
                column: "ID_CoSo");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_ID_Lau",
                table: "Phong",
                column: "ID_Lau");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_ID_LoaiPhong",
                table: "Phong",
                column: "ID_LoaiPhong");

            migrationBuilder.CreateIndex(
                name: "IX_PhongBan_ID_LoaiPhongBan",
                table: "PhongBan",
                column: "ID_LoaiPhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_ID_CoSo",
                table: "TaiKhoan",
                column: "ID_CoSo");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_ID_PhongBan",
                table: "TaiKhoan",
                column: "ID_PhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_QuyenHan_ID_QuyenHan",
                table: "TaiKhoan_QuyenHan",
                column: "ID_QuyenHan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTiet_HoaDon");

            migrationBuilder.DropTable(
                name: "ChiTiet_QuyenHan");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.DropTable(
                name: "TaiKhoan_QuyenHan");

            migrationBuilder.DropTable(
                name: "DichVu");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "QuyenHan");

            migrationBuilder.DropTable(
                name: "LoaiDichVu");

            migrationBuilder.DropTable(
                name: "DatPhong");

            migrationBuilder.DropTable(
                name: "GiaoCa");

            migrationBuilder.DropTable(
                name: "GiaoDich");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "Lau");

            migrationBuilder.DropTable(
                name: "LoaiPhong");

            migrationBuilder.DropTable(
                name: "PhongBan");

            migrationBuilder.DropTable(
                name: "CoSo");

            migrationBuilder.DropTable(
                name: "LoaiPhongBans");

            migrationBuilder.DropTable(
                name: "Quan_Huyen");

            migrationBuilder.DropTable(
                name: "TaiKhoan_NganHang");

            migrationBuilder.DropTable(
                name: "Tinh_ThanhPho");
        }
    }
}
