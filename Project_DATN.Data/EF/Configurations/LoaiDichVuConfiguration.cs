using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class LoaiDichVuConfiguration : IEntityTypeConfiguration<LoaiDichVu>
    {
        public void Configure(EntityTypeBuilder<LoaiDichVu> builder)
        {
            builder.ToTable("LoaiDichVu");
            builder.HasKey(ldv => ldv.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(ldv => ldv.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(ldv => ldv.tenLoaiDichVu).HasMaxLength(30);
            builder.Property(ldv => ldv.moTa).HasMaxLength(60);
            builder.Property(ldv => ldv.trangThai).HasMaxLength(30);
        }
    }
}
