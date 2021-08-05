using System.Collections.Generic;
using System.Linq;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.PhamVietIServices;

namespace Project_DATN.Services.Services.PhamVietServices
{
    public class QuyenHanService : IQuyenHanService
    {
        private readonly DB_Context _context;
        private List<QuyenHan> _lstQuyenHan;
        public QuyenHanService(DB_Context context)
        {
            _context = context;
            GetAllQuyenHan();
        }
        public List<QuyenHan> GetAllQuyenHan()
        {
             _lstQuyenHan = _context.QuyenHans.ToList();
             return _lstQuyenHan;
        }

        public QuyenHan FindById(int id)
        {
            var qh = _lstQuyenHan.FirstOrDefault(x => x.ID.Equals(id));
            return qh;
        }

        public QuyenHan Add(QuyenHan qh)
        {
            _context.QuyenHans.Add(qh);
            _context.SaveChangesAsync();
            return qh;
        }

        public QuyenHan Edit(QuyenHan qh)
        {
            var newQh = _context.QuyenHans.FirstOrDefault(x => x.ID.Equals(qh.ID));
            if (newQh == null) return null;
            newQh.tenQuyenHan = qh.tenQuyenHan;
            newQh.moTa = qh.moTa;
            newQh.trangThai = qh.trangThai;
            _context.QuyenHans.Update(newQh);
            _context.SaveChangesAsync();
            return qh;
        }

        public void Delete(int id)
        {
            var qh = _context.QuyenHans.FirstOrDefault(x => x.ID == id);
            if (qh == null) return;
            _context.QuyenHans.Remove(qh);
            _context.SaveChangesAsync();
        }
    }
}
