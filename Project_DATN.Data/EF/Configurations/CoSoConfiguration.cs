using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class CoSoConfiguration : IEntityTypeConfiguration<CoSo>
    {
        public void Configure(EntityTypeBuilder<CoSo> builder)
        {
            builder.ToTable("CoSo");
            builder.HasKey(cs => cs.ID);
            builder.Property(cs => cs.ID).UseIdentityColumn();
            //builder.Property(cs => cs.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(cs => cs.maCoSo).IsUnicode(false).HasMaxLength(10);
            builder.Property(cs => cs.tenCoSo).HasMaxLength(50);
            builder.Property(cs => cs.hoTenNguoiDaiDien).HasMaxLength(50);
            builder.Property(cs => cs.maSoThue).IsUnicode(false).HasMaxLength(15);
            builder.Property(cs => cs.soDienThoai).IsUnicode(false).HasMaxLength(11);
            builder.Property(cs => cs.email).IsUnicode(false).HasMaxLength(60);
            builder.Property(cs => cs.ghiChu).HasMaxLength(100);
            builder.Property(cs => cs.trangThai).HasMaxLength(30);
            builder.HasOne(cs => cs.TinhThanhPho).WithMany(cs => cs.ICCoSo).HasForeignKey(cs => cs.ID_Tinh_TP).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(cs => cs.QuanHuyen).WithMany(cs => cs.ICCoSo).HasForeignKey(cs => cs.ID_Quan_Huyen).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(cs => cs.TaiKhoanNganHang).WithMany(cs => cs.ICCoSo).HasForeignKey(cs => cs.ID_TK_NH).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
