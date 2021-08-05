using Project_DATN.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_DATN.Services.IServices.PhuIServices
{
    public interface IAutoRenderRoomService
    {
        public Task<bool> AutoRenderRoom(CoSo cs, string kyhieuphong, int solau, List<string> soluongphong,int idloaiphong);

        public Task<bool> CreateCoso(CoSo cs, int solau);
    }
}
