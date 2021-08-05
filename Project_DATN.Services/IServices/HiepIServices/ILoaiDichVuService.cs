using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.IServices.HiepIServices
{
    public interface ILoaiDichVuService
    {
        public LoaiDichVu GetLoaiDichVu(int idLoaiDichVu);
        public List<LoaiDichVu> GetAllLoaiDichVu();
        public bool AddLoaiDichVu(LoaiDichVu ldv);
        public bool EditLoaiDichVu(LoaiDichVu ldv);
        public bool DeleteLoaiDichVu(int id);
    }
}
