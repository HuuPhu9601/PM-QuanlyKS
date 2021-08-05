using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class Tinh_ThanhPhoConfiguration : IEntityTypeConfiguration<Tinh_ThanhPho>
    {
        public void Configure(EntityTypeBuilder<Tinh_ThanhPho> builder)
        {
            builder.ToTable("Tinh_ThanhPho");
            builder.HasKey(tp => tp.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(tp => tp.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(tp => tp.tenTinh).HasMaxLength(30);
            builder.Property(tp => tp.trangThai).HasMaxLength(30);
        }
    }
}
