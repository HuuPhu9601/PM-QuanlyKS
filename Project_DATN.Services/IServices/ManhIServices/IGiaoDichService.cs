using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.IServices.ManhIServices
{
    public interface IGiaoDichService
    {
        public GiaoDich GetGiaoDich(int idGiaoDich);
        public List<GiaoDich> GetAllGiaoDich();
        public bool AddGiaoDich(GiaoDich gd);
        public bool EditGiaoDich(GiaoDich gd);
        public bool DeleteGiaoDich(int id);
    }
}
