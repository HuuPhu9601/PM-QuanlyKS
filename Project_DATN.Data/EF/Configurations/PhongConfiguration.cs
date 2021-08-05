using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class PhongConfiguration : IEntityTypeConfiguration<Phong>
    {
        public void Configure(EntityTypeBuilder<Phong> builder)
        {
            builder.ToTable("Phong");
            builder.HasKey(p => p.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(p => p.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(p => p.tenPhong).HasMaxLength(10);
            builder.Property(p => p.ghiChu).HasMaxLength(100);
            builder.Property(p => p.trangThai).HasMaxLength(30);
            builder.HasOne(p => p.LoaiPhong).WithMany(p => p.ICPhong).HasForeignKey(p => p.ID_LoaiPhong).OnDelete(DeleteBehavior.NoAction).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.CoSo).WithMany(p => p.ICPhong).HasForeignKey(p => p.ID_CoSo).OnDelete(DeleteBehavior.NoAction).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Lau).WithMany(p => p.ICPhong).HasForeignKey(p => p.ID_Lau).OnDelete(DeleteBehavior.NoAction).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
