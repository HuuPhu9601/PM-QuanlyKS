using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class GiaoDichConfiguration : IEntityTypeConfiguration<GiaoDich>
    {
        public void Configure(EntityTypeBuilder<GiaoDich> builder)
        {
            builder.ToTable("GiaoDich");
            builder.HasKey(gd => gd.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(gd => gd.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(gd => gd.loaiHinhThucThanhToan).HasMaxLength(50);
            builder.Property(gd => gd.ngayGioThanhToan).IsRequired();
            builder.Property(gd => gd.trangThai).HasMaxLength(30);
        }
    }
}
