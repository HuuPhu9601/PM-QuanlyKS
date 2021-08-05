using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class LoaiPhongConfiguration : IEntityTypeConfiguration<LoaiPhong>
    {
        public void Configure(EntityTypeBuilder<LoaiPhong> builder)
        {
            builder.ToTable("LoaiPhong");
            builder.HasKey(lp => lp.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(lp => lp.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(lp => lp.tenLoaiPhong).HasMaxLength(30);
            builder.Property(lp => lp.ghiChu).HasMaxLength(100);
            builder.Property(lp => lp.trangThai).HasMaxLength(30);
        }
    }
}
