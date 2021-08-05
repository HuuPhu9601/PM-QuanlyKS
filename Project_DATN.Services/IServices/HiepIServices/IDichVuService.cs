using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.IServices.HiepIServices
{
    public interface IDichVuService
    {
        public DichVu GetDichVu(int idDichVu);
        public List<DichVu> GetAllDichVu();
        public bool AddDichVu(DichVu dv);
        public bool EditDichVu(DichVu dv);
        public bool DeleteDichVu(int id);
    }
}
