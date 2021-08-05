using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.IServices.PhuIServices
{
    public interface ICosoService
    {
        public Task<List<CosoRequest>> GetAll();

        public Task<CoSo> GetCosoById(int id);

        public Task<bool> CraeteCoso(CoSo cs);

        public Task<bool> UpdateCoso(int id, CoSo cs);

        public Task<bool> RemoveCoso(int id);
    }
}
