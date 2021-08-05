using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class TaiKhoan_QuyenHanConfiguration : IEntityTypeConfiguration<TaiKhoan_QuyenHan>
    {
        public void Configure(EntityTypeBuilder<TaiKhoan_QuyenHan> builder)
        {
            builder.ToTable("TaiKhoan_QuyenHan");
            builder.HasKey(_t => _t.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(_t => _t.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(_t => _t.maSuDung).IsUnicode(false).HasMaxLength(30);
            builder.Property(_t => _t.moTa).HasMaxLength(60);
            builder.Property(_t => _t.trangThai).HasMaxLength(30);
            builder.HasOne(_t => _t.TaiKhoan).WithMany(_t => _t.IC_TK_QH).HasForeignKey(_t => _t.ID_QuyenHan).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(_t => _t.QuyenHan).WithMany(_t => _t.IC_TK_QH).HasForeignKey(_t => _t.ID_QuyenHan).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
