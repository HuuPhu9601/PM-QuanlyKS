using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class ChiTiet_HoaDonConfiguration : IEntityTypeConfiguration<ChiTiet_HoaDon>
    {
        public void Configure(EntityTypeBuilder<ChiTiet_HoaDon> builder)
        {
            builder.ToTable("ChiTiet_HoaDon");
            builder.HasKey(cthd => cthd.ID);
            builder.Property(cthd => cthd.ID).UseIdentityColumn();
            //builder.Property(cthd => cthd.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(cthd => cthd.ghiChu).HasMaxLength(60);
            builder.Property(cthd => cthd.trangThai).HasMaxLength(30);
            builder.HasOne(cthd => cthd.HoaDon).WithMany(cthd => cthd.ICChiTiet_HoaDon).HasForeignKey(cthd => cthd.ID_HoaDon).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(cthd => cthd.DichVu).WithMany(cthd => cthd.ICChiTietHoaDon).HasForeignKey(cthd => cthd.ID_DichVu).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
