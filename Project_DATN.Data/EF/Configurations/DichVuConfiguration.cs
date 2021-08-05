using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class DichVuConfiguration : IEntityTypeConfiguration<DichVu>
    {
        public void Configure(EntityTypeBuilder<DichVu> builder)
        {
            builder.ToTable("DichVu");
            builder.HasKey(dv => dv.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(dv => dv.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(dv => dv.tenDichVu).HasMaxLength(50);
            builder.Property(dv => dv.donViTinh).HasMaxLength(20);
            builder.Property(dv => dv.donViTien).HasMaxLength(10);
            builder.Property(dv => dv.moTa).HasMaxLength(100);
            builder.Property(dv => dv.trangThai).HasMaxLength(30);
            builder.HasOne(dv => dv.LoaiDichVu).WithMany(dv => dv.ICDichVu).HasForeignKey(dv => dv.ID_LoaiDichVu).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
