using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices;
using System.Collections.Generic;
using System.Linq;

namespace Project_DATN.Services.Services
{
    public class GiaoCaService : IGiaoCaService
    {
        private readonly DB_Context _DBContext;


        public GiaoCaService(DB_Context dB_Context)
        {
            _DBContext = dB_Context;
        }

        public GiaoCa AddGiaoCa(GiaoCa giaoCa)
        {
            _DBContext.GiaoCas.Add(giaoCa);
            _DBContext.SaveChanges();
            return giaoCa;
        }

        public List<HoaDon> GetListHoaDon()
        {
            return _DBContext.HoaDons.ToList();
        }

        public List<GiaoCa> GetListGiaoCa()
        {
            return _DBContext.GiaoCas.ToList();
        }



        public void UpdateGiaoCa(GiaoCa giaoCa)
        {
            _DBContext.GiaoCas.Update(giaoCa);
            _DBContext.SaveChanges();
        }

    }
}
