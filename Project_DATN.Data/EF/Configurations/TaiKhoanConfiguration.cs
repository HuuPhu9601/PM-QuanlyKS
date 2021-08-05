using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Data.EF.Configurations
{
    public class TaiKhoanConfiguration : IEntityTypeConfiguration<TaiKhoan>
    {
        public void Configure(EntityTypeBuilder<TaiKhoan> builder)
        {
            builder.ToTable("TaiKhoan");
            builder.HasKey(tk => tk.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            //builder.Property(bs => bs.ID).HasDefaultValueSql("newsequentialid()");
            builder.Property(tk => tk.tenTaiKhoan).IsUnicode(false).HasMaxLength(30);
            builder.Property(tk => tk.matKhau).HasMaxLength(60);
            builder.Property(tk => tk.hoTenChuTK).HasMaxLength(30);
            builder.Property(tk => tk.email).IsUnicode(false).HasMaxLength(60);
            builder.Property(tk => tk.soDienThoai).IsUnicode(false);
            builder.Property(tk => tk.CCCD).IsUnicode(false);
            builder.Property(tk => tk.anhDaiDien).HasColumnType("nvarchar(886)");
            builder.Property(tk => tk.ngayThangNamSinh).HasColumnType("DATE");
            builder.HasOne(tk => tk.PhongBan).WithMany(tk => tk.ICTaiKhoan).HasForeignKey(tk => tk.ID_PhongBan).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(tk => tk.CoSo).WithMany(tk => tk.ICTaiKhoan).HasForeignKey(tk => tk.ID_CoSo).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
