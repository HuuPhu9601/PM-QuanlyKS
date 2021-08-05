using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class TaiKhoan_NganHangConfiguration : IEntityTypeConfiguration<TaiKhoan_NganHang>
    {
        public void Configure(EntityTypeBuilder<TaiKhoan_NganHang> builder)
        {
            builder.ToTable("TaiKhoan_NganHang");
            builder.HasKey(tn => tn.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(tn => tn.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(tn => tn.hoTenChuTKNH).HasMaxLength(20);
            builder.Property(tn => tn.soTaiKhoan).IsUnicode(false).HasMaxLength(15);
            builder.Property(tn => tn.tenNganHang).HasMaxLength(100);
            builder.Property(tn => tn.tenChiNhanh).HasMaxLength(50);
            builder.Property(tn => tn.diaChiCN).HasMaxLength(100);
            builder.Property(tn => tn.ghiChu).HasMaxLength(100);
            builder.Property(tn => tn.trangThai).HasMaxLength(30);
        }
    }
}
