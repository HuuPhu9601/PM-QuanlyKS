using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DATN.Services.IServices
{
    public interface IGiaoCaService
    {
        GiaoCa AddGiaoCa(GiaoCa giaoCa);
        List<HoaDon> GetListHoaDon();
        void UpdateGiaoCa(GiaoCa giaoCa);
        List<GiaoCa> GetListGiaoCa();

        
    }
}
