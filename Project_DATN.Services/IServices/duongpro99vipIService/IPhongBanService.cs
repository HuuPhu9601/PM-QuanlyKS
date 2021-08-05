using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Services.IServices.duongpro99vipIService
{
    public interface IPhongBanService
    {
        List<PhongBan> GetAllPhongBan();
        PhongBan FindById(int id);
        Task<PhongBan> Create(PhongBan phongBan);
        Task<PhongBan> Edit(PhongBan phongBan);
        Task<int> Delete(int id);
    }
}
