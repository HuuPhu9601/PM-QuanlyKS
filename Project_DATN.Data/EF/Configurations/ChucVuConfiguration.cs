using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class ChucVuConfiguration : IEntityTypeConfiguration<ChucVu>
    {
        public void Configure(EntityTypeBuilder<ChucVu> builder)
        {
            builder.ToTable("ChucVu");
            builder.HasKey(cv => cv.ID);
            builder.Property(cv => cv.ID).UseIdentityColumn();
            //builder.Property(cv => cv.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(cv => cv.tenChucVu).HasMaxLength(30);
            builder.Property(cv => cv.ghiChu).HasMaxLength(100);
            builder.HasOne(cv => cv.TaiKhoan).WithMany(cs => cs.ICChucVu).HasForeignKey(cs => cs.ID_TaiKhoan)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(cv => cv.PhongBan).WithMany(cs => cs.ICChucVu).HasForeignKey(cs => cs.ID_PhongBan)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
