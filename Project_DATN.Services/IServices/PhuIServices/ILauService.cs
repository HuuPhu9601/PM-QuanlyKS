using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.IServices.PhuIServices
{
    public interface ILauService
    {
        public Task<List<LauRequest>> GetAll();

        public Task<Lau> GetLauById(int id);

        public Task<bool> CraeteLau(Lau cs);

        public Task<bool> UpdateLau(int id, Lau cs);

        public Task<bool> RemoveLau(int id);
    }
}
