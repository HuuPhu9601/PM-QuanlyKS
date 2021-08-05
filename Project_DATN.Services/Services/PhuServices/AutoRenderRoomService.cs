using Microsoft.EntityFrameworkCore;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.DataProviders;
using Project_DATN.Services.IServices.PhuIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_DATN.Services.Services.PhuServices
{
    public class AutoRenderRoomService : IAutoRenderRoomService
    {
        private readonly ICosoService _CsService;
        private readonly ILauService _LauService;
        private readonly IPhongService _PhongService;
        public AutoRenderRoomService(ICosoService CsService, ILauService LauService, IPhongService PhongService)
        {
            _CsService = CsService;
            _LauService = LauService;
            _PhongService = PhongService;
        }

        public async Task<bool> AutoRenderRoom(CoSo cs, string kyhieuphong, int solau, List<string> soluongphong, int idloaiphong)
        {
            if (cs == null || string.IsNullOrEmpty(kyhieuphong))
            {
                return false;
            }
            
            //tao phong
            var getListTang = await DataProvider.Ins.DB.Laus.Where(x => x.ID_CoSo == cs.ID).ToListAsync();
            if (getListTang.Count == 0)
            {
                return false;
            }
            for (int j = 0; j < soluongphong.Count;j ++)
            {
                int idtang = getListTang[j].ID;
                for (int i = 0; i < int.Parse(soluongphong[j]); i++)
                {
                    Phong phong = new Phong();
                    phong.ID_LoaiPhong = idloaiphong;
                    phong.ID_CoSo = cs.ID;
                    phong.ID_Lau = idtang;
                    phong.trangThai = "Active";

                    int tang =j + 1;
                    int tenphong = i + 1;
                    if (getListTang[j].soLuongLau < 10)
                    {
                        
                        phong.tenPhong = kyhieuphong + " " + tang + "0" + tenphong;
                    }
                    else
                    {
                        phong.tenPhong = kyhieuphong + " " + tang + tenphong;
                    }
                    var result = await _PhongService.CraetePhong(phong);
                    if (!result)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public async Task<bool> CreateCoso(CoSo cs, int solau)
        {
            if (cs == null)
            {
                return false;
            }
            //Tao coso
            var addCoso = await _CsService.CraeteCoso(cs);
            if (!addCoso)
            {
                return false;
            }

            //tao tang
            var getIdcoso = DataProvider.Ins.DB.CoSos.Where(x => x.tenCoSo == cs.tenCoSo).Single().ID;
            for (int i = 1; i <= solau; i++)
            {
                Lau laus = new Lau()
                {
                    ID_CoSo = getIdcoso,
                    tenLau = "Tầng " + i,
                    trangThai = "Active",
                    //soLuongLau = int.Parse(soluongphong[i - 1]),
                };
                var resultLau = await _LauService.CraeteLau(laus);
                if (!resultLau)
                {
                    break;
                }
                Thread.Sleep(TimeSpan.FromSeconds(0.2));
            }
            return true;
        }
    }
}
