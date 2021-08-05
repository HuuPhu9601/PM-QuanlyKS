using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class LoaiPhongBanConfiguration : IEntityTypeConfiguration<LoaiPhongBan>
    {
        public void Configure(EntityTypeBuilder<LoaiPhongBan> builder)
        {
            builder.ToTable("LoaiPhongBan");
            builder.HasKey(lpb => lpb.ID);
            builder.Property(lpb => lpb.ID).UseIdentityColumn();
            //builder.Property(lpb => lpb.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(lpb => lpb.tenLoaiPhongBan).HasMaxLength(50);
            builder.Property(lpb => lpb.ghiChu).HasMaxLength(100);
        }
    }
}
