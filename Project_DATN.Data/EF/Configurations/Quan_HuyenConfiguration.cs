using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class Quan_HuyenConfiguration : IEntityTypeConfiguration<Quan_Huyen>
    {
        public void Configure(EntityTypeBuilder<Quan_Huyen> builder)
        {
            builder.ToTable("Quan_Huyen");
            builder.HasKey(qh => qh.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(qh => qh.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(qh => qh.tenQuan_Huyen).HasMaxLength(30);
            builder.Property(qh => qh.trangThai).HasMaxLength(30);
        }
    }
}
