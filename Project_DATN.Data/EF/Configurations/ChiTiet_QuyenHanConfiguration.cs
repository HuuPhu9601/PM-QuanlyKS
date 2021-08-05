using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class ChiTiet_QuyenHanConfiguration : IEntityTypeConfiguration<ChiTiet_QuyenHan>
    {
        public void Configure(EntityTypeBuilder<ChiTiet_QuyenHan> builder)
        {
            builder.ToTable("ChiTiet_QuyenHan");
            builder.HasKey(cq => cq.ID);
            builder.Property(cq => cq.ID).UseIdentityColumn();
            //builder.Property(cq => cq.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(cq => cq.maHanhDong).IsUnicode(false).HasMaxLength(30);
            builder.Property(cq => cq.kiemTraHanhDong).HasMaxLength(20);
            builder.Property(cq => cq.moTa).HasMaxLength(60);
            builder.Property(cq => cq.trangThai).HasMaxLength(30);
            builder.HasOne(cq => cq.QuyenHan).WithMany(cq => cq.IC_ChiTiet_QuyenHan).HasForeignKey(cq => cq.ID_QuyenHan).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
