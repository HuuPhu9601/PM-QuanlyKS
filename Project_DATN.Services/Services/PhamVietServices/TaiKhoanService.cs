using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.PhamVietIServices;

namespace Project_DATN.Services.Services.PhamVietServices
{
    public class TaiKhoanService:ITaiKhoanService
    {
        private readonly DB_Context _context;
        private List<TaiKhoan> _lstTaiKhoan;

        public TaiKhoanService(DB_Context context)
        {
            _context = context;
            GetAllTaiKhoan();
        }
        public List<TaiKhoan> GetAllTaiKhoan()
        {
            _lstTaiKhoan = _context.TaiKhoans.Include(x=>x.CoSo).Include(x=>x.PhongBan).ToList();
            return _lstTaiKhoan;
        }

        public TaiKhoan FindById(int id)
        {
            return _lstTaiKhoan.FirstOrDefault(x => x.ID.Equals(id));
        }
        //Thêm tài khoản
        public async Task<TaiKhoan> Add(TaiKhoan tk)
        {
            
            _context.TaiKhoans.Add(tk);
           await _context.SaveChangesAsync();
            return tk;
        }

        public async Task<TaiKhoan> Edit(TaiKhoan tk)
        {
            var taiKhoan = _lstTaiKhoan.FirstOrDefault(x => x.ID.Equals(tk.ID));
            if (taiKhoan == null) return null;
           taiKhoan.ID_CoSo = tk.ID_CoSo;
            taiKhoan.ID_PhongBan = tk.ID_PhongBan;
            taiKhoan.tenTaiKhoan = tk.tenTaiKhoan;
            taiKhoan.matKhau = tk.matKhau;
            taiKhoan.hoTenChuTK = tk.hoTenChuTK;
            taiKhoan.email = tk.email;
            taiKhoan.ngayThangNamSinh = tk.ngayThangNamSinh;
            taiKhoan.gioiTinh = tk.gioiTinh;
            taiKhoan.soDienThoai = tk.soDienThoai;
            taiKhoan.CCCD = tk.CCCD;
            taiKhoan.diaChi = tk.diaChi;
            taiKhoan.ngayVaoLam = tk.ngayVaoLam;
            taiKhoan.ngayKetThucHopDong = tk.ngayKetThucHopDong;
            taiKhoan.TrangThai = tk.TrangThai;
            taiKhoan.anhDaiDien = tk.anhDaiDien;
            _context.TaiKhoans.Update(taiKhoan);
           await _context.SaveChangesAsync();
            return tk;
        }

        public async Task<int> Delete(int id)
        {
            var tk = _lstTaiKhoan.Find(x => x.ID.Equals(id));
            if (tk == null) return -1;
            _context.TaiKhoans.Remove(tk);
          await  _context.SaveChangesAsync();
            return 0;
        }
    }
}
