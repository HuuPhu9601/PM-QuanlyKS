using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class LauConfiguration : IEntityTypeConfiguration<Lau>
    {
        public void Configure(EntityTypeBuilder<Lau> builder)
        {
            builder.ToTable("Lau");
            builder.HasKey(l => l.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(l => l.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(l => l.tenLau).HasMaxLength(10);
            builder.Property(l => l.ghiChu).HasMaxLength(100);
            builder.Property(l => l.trangThai).HasMaxLength(30);
            builder.HasOne(l => l.CoSo).WithMany(l => l.ICLau).HasForeignKey(l => l.ID_CoSo).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
