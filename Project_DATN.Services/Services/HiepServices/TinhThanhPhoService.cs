using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.HiepIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_DATN.Services.Services.HiepServices
{
    public class TinhThanhPhoService : ITinhThanhPhoService
    {
        private readonly DB_Context _Context;
        public TinhThanhPhoService(DB_Context context)
        {
            _Context = context;
        }

        public bool AddTinhThanhPho(Tinh_ThanhPho tp)
        {
            if (tp != null)
            {
                var TinhThanhPho = new Tinh_ThanhPho()
                {
                    tenTinh = tp.tenTinh,
                    trangThai = tp.trangThai,

                };
                _Context.TinhThanhPhos.Add(TinhThanhPho);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditTinhThanhPho(Tinh_ThanhPho tp)
        {
            var FindTp = _Context.TinhThanhPhos.FirstOrDefault(x => x.ID == tp.ID);
            if (FindTp == null)
            {
                return false;
            }
            else
            {
                FindTp.tenTinh = tp.tenTinh;
                FindTp.trangThai = tp.trangThai;

                _Context.TinhThanhPhos.Update(FindTp);
                _Context.SaveChanges();
                return true;
            }
        }

        public List<Tinh_ThanhPho> GetAllTinhThanhPho()
        {
            return _Context.TinhThanhPhos.Select(x => new Tinh_ThanhPho()
            {
                ID = x.ID,
                tenTinh = x.tenTinh,
                trangThai = x.trangThai
            }).ToList();
        }

        public Tinh_ThanhPho GetTinhThanhPho(int IdTinhThanhPho)
        {
            return _Context.TinhThanhPhos.Find(IdTinhThanhPho);
        }
    }
}
