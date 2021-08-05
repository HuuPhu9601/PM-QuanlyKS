using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class PhongBanConfiguration : IEntityTypeConfiguration<PhongBan>
    {
        public void Configure(EntityTypeBuilder<PhongBan> builder)
        {
            builder.ToTable("PhongBan");
            builder.HasKey(pb => pb.ID);
            builder.Property(pb => pb.ID).UseIdentityColumn();
            //builder.Property(pb => pb.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(pb => pb.tenPhongBan).HasMaxLength(50);
            builder.Property(pb => pb.ghiChu).HasMaxLength(100);
            builder.HasOne(pb => pb.LoaiPhongBan).WithMany(pb => pb.ICPhongBan).HasForeignKey(pb => pb.ID_LoaiPhongBan).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
