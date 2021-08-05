using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class DatPhongConfiguration : IEntityTypeConfiguration<DatPhong>
    {
        public void Configure(EntityTypeBuilder<DatPhong> builder)
        {
            builder.ToTable("DatPhong");
            builder.HasKey(dp => dp.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(dp => dp.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(dp => dp.maDatPhong).IsUnicode(false).HasMaxLength(20);
            builder.Property(dp => dp.thoiGianLuuTru).HasMaxLength(30);
            builder.Property(dp => dp.thuCung).HasMaxLength(50);
            builder.Property(dp => dp.ghiChu).HasMaxLength(100);
            builder.Property(dp => dp.trangThai).HasMaxLength(30);
            builder.HasOne(dp => dp.KhachHang).WithMany(dp => dp.ICDatPhong).HasForeignKey(dp => dp.ID_KhachHang).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(dp => dp.LoaiPhong).WithMany(dp => dp.ICDatPhong).HasForeignKey(dp => dp.ID_LoaiPhong).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
