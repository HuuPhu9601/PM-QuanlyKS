using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.IServices.HiepIServices
{
    public interface IQuanhuyenService
    {
        public Quan_Huyen GetQuanHuyen(int IdQuanHuyen);
        public List<Quan_Huyen> GetAllQuanHuyen();
        public bool AddQuanHuyen(Quan_Huyen qh);
        public bool EditQuanHuyen(Quan_Huyen qh);
     
    }
}
