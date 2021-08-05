using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project_DATN.Data.EF.Configurations;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Data.Extensions;

namespace Project_DATN.Data.EF.DBContext
{
    public class DB_Context : DbContext
    {
        public DB_Context()
        {
                
        }

        public DB_Context(DbContextOptions<DB_Context> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DATN");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Tinh_ThanhPhoConfiguration());
            modelBuilder.ApplyConfiguration(new Quan_HuyenConfiguration());
            modelBuilder.ApplyConfiguration(new TaiKhoan_NganHangConfiguration());
            modelBuilder.ApplyConfiguration(new CoSoConfiguration());
            modelBuilder.ApplyConfiguration(new LauConfiguration());
            modelBuilder.ApplyConfiguration(new LoaiPhongConfiguration());
            modelBuilder.ApplyConfiguration(new PhongConfiguration());
            modelBuilder.ApplyConfiguration(new GiaoDichConfiguration());
            modelBuilder.ApplyConfiguration(new TaiKhoanConfiguration());
            modelBuilder.ApplyConfiguration(new LuongConfiguration());
            modelBuilder.ApplyConfiguration(new ChucVuConfiguration());
            modelBuilder.ApplyConfiguration(new PhongBanConfiguration());
            modelBuilder.ApplyConfiguration(new KhachHangConfiguration());
            modelBuilder.ApplyConfiguration(new QuyenHanConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTiet_QuyenHanConfiguration());
            modelBuilder.ApplyConfiguration(new TaiKhoan_QuyenHanConfiguration());
            modelBuilder.ApplyConfiguration(new DatPhongConfiguration());
            modelBuilder.ApplyConfiguration(new GiaoCaConfiguration());
            modelBuilder.ApplyConfiguration(new HoaDonConfiguration());
            modelBuilder.ApplyConfiguration(new LoaiDichVuConfiguration());
            modelBuilder.ApplyConfiguration(new DichVuConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTiet_HoaDonConfiguration());

            modelBuilder.Seed();
        }

        public DbSet<Tinh_ThanhPho> TinhThanhPhos { get; set; }
        public DbSet<Quan_Huyen> QuanHuyens { get; set; }
        public DbSet<TaiKhoan_NganHang> TaiKhoanNganHangs { get; set; }
        public DbSet<CoSo> CoSos { get; set; }
        public DbSet<Lau> Laus { get; set; }
        public DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public DbSet<Phong> Phongs { get; set; }
        public DbSet<GiaoDich> GiaoDichs { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<Luong> Luongs { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<LoaiPhongBan> LoaiPhongBans { get; set; }
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<QuyenHan> QuyenHans { get; set; }
        public DbSet<ChiTiet_QuyenHan> ChiTietQuyenHans { get; set; }
        public DbSet<TaiKhoan_QuyenHan> TaiKhoanQuyenHans { get; set; }
        public DbSet<DatPhong> DatPhongs { get; set; }
        public DbSet<GiaoCa> GiaoCas { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<LoaiDichVu> LoaiDichVus { get; set; }
        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<ChiTiet_HoaDon> ChiTietHoaDons { get; set; }
    }
}
