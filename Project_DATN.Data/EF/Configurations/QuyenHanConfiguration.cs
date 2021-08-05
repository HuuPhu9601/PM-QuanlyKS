using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class QuyenHanConfiguration : IEntityTypeConfiguration<QuyenHan>
    {
        public void Configure(EntityTypeBuilder<QuyenHan> builder)
        {
            builder.ToTable("QuyenHan");
            builder.HasKey(qh => qh.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(qh => qh.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(qh => qh.tenQuyenHan).HasMaxLength(30);
            builder.Property(qh => qh.moTa).HasMaxLength(60);
        }
    }
}
