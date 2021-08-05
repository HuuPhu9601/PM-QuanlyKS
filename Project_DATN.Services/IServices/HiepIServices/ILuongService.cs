using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.IServices.HiepIServices
{
    public interface ILuongService
    {
        public Luong GetLuong(int IdLuong);
        public List<Luong> GetAllLuong();
        public bool AddLuong(Luong lg);
        public bool EditLuong(Luong lg);
        public bool DeleteLuong(int id);
    }
}
