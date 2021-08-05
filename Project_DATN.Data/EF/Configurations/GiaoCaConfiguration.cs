using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class GiaoCaConfiguration : IEntityTypeConfiguration<GiaoCa>
    {
        public void Configure(EntityTypeBuilder<GiaoCa> builder)
        {
            builder.ToTable("GiaoCa");
            builder.HasKey(gc => gc.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(gc => gc.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(gc => gc.caLam).HasMaxLength(10);
            builder.Property(gc => gc.ghiChu).HasMaxLength(100);
            builder.Property(gc => gc.trangThai).HasMaxLength(30);
            builder.HasOne(gc => gc.TaiKhoan).WithMany(cs => cs.ICGiaoCa).HasForeignKey(cs => cs.ID_TaiKhoan).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
