using System.Collections.Generic;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Services.IServices.PhamVietIServices
{
    public interface IQuyenHanService
    {
        List<QuyenHan> GetAllQuyenHan();
        QuyenHan FindById(int id);
        QuyenHan Add(QuyenHan qh);
        QuyenHan Edit(QuyenHan qh);
        void Delete(int id);
    }
}
