using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class KhachHangConfiguration : IEntityTypeConfiguration<KhachHang>
    {
        public void Configure(EntityTypeBuilder<KhachHang> builder)
        {
            builder.ToTable("KhachHang");
            builder.HasKey(kh => kh.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(kh => kh.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(kh => kh.maKH).IsUnicode(false).HasMaxLength(10);
            builder.Property(kh => kh.hoTenKH).HasMaxLength(30);
            builder.Property(kh => kh.email).IsUnicode(false).HasMaxLength(60);
            builder.Property(kh => kh.soDienThoai).IsUnicode(false);
            builder.Property(kh => kh.CCCD).IsUnicode(false);
            builder.Property(kh => kh.gioiTinh).HasMaxLength(30);
            builder.Property(kh => kh.diaChi).HasMaxLength(50);
            builder.Property(kh => kh.quocTich).HasMaxLength(60);
            builder.Property(kh => kh.trangThai).HasMaxLength(30);
        }
    }
}
