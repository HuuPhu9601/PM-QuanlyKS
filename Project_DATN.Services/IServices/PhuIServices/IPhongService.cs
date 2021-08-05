using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.IServices.PhuIServices
{
    public interface IPhongService
    {
        public Task<List<Phong>> GetAll();

        public Task<Phong> GetPhongById(int id);

        public Task<bool> CraetePhong(Phong phong);

        public Task<bool> UpdatePhong(int id, Phong phong);

        public Task<bool> RemovePhong(int id);
    }
}
