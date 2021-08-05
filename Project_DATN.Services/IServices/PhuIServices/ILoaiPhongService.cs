using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.IServices.PhuIServices
{
    public interface ILoaiPhongService
    {
        public Task<List<LoaiPhong>> GetAll();

        public Task<LoaiPhong> GetLoaiPhongById(int id);

        public Task<bool> CraeteLoaiPhong(LoaiPhong tknh);

        public Task<bool> UpdateLoaiPhong(int id, LoaiPhong tknh);

        public Task<bool> RemoveLoaiPhong(int id);

        public Task<bool> AddQRcode(LoaiPhong lp);
    }
}
