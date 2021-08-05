using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class LuongConfiguration : IEntityTypeConfiguration<Luong>
    {
        public void Configure(EntityTypeBuilder<Luong> builder)
        {
            builder.ToTable("Luong");
            builder.HasKey(s => s.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(s => s.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(s => s.ghiChu).HasMaxLength(100);
            builder.Property(s => s.trangThai).HasMaxLength(30);
            builder.HasOne(s => s.TaiKhoan).WithMany(cs => cs.ICLuong).HasForeignKey(cs => cs.ID_TaiKhoan).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
