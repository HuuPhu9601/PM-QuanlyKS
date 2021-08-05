using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.IServices.ManhIServices
{
    public interface IHoaDonService
    {
        public List<HoaDon> GetAll();
        public HoaDon GetHoaDon(int idHoaDon);
        public bool AddHoaDon(HoaDon hd,int idPhong);
        public bool EditHoaDon(HoaDon hd);
        public bool DeleteHoaDon(int idHoaDon);
        public List<HoaDon> getHoaDonByDate(DateTime to, DateTime from);
        public (List<HoaDon> hoaDons, int pages, int page) Paging(int page);
    }
}
