
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class HoaDonConfiguration : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.ToTable("HoaDon");
            builder.HasKey(hd => hd.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(hd => hd.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(hd => hd.maHoaDon).IsUnicode(false).HasMaxLength(10);
            builder.Property(hd => hd.thoiGianThue).HasMaxLength(30);
            builder.Property(hd => hd.ghiChu).HasMaxLength(100);
            builder.Property(hd => hd.trangThai).HasMaxLength(30);
            builder.HasOne(hd => hd.KhachHang).WithMany(hd => hd.ICHoaDon).HasForeignKey(hd => hd.ID_KhachHang).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(hd => hd.TaiKhoan).WithMany(hd => hd.ICHoaDon).HasForeignKey(hd => hd.ID_TaiKhoan).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(hd => hd.GiaoDich).WithMany(hd => hd.ICHoaDon).HasForeignKey(hd => hd.ID_GiaoDich).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(hd => hd.GiaoCa).WithMany(hd => hd.ICHoaDon).HasForeignKey(hd => hd.ID_GiaoCa).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(hd => hd.LoaiPhong).WithMany(hd => hd.ICHoaDon).HasForeignKey(hd => hd.ID_LoaiPhong).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(hd => hd.Phong).WithMany(hd => hd.ICHoaDon).HasForeignKey(hd => hd.ID_Phong).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
