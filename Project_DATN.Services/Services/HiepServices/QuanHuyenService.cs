using Project_DATN.Data.EF.DBContext;
using Project_DATN.Data.EF.Entities;
using Project_DATN.Services.IServices.HiepIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_DATN.Services.Services.HiepServices
{
    public class QuanHuyenService : IQuanhuyenService
    {
        private readonly DB_Context _Context;
        public QuanHuyenService(DB_Context context)
        {
            _Context = context;
        }

        public bool AddQuanHuyen(Quan_Huyen qh)
        {
            if (qh != null)
            {
                var QuanHuyen = new Quan_Huyen()
                {
                    tenQuan_Huyen = qh.tenQuan_Huyen,
                    trangThai = qh.trangThai,

                };
                _Context.QuanHuyens.Add(QuanHuyen);
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditQuanHuyen(Quan_Huyen qh)
        {
            var FindQh = _Context.QuanHuyens.FirstOrDefault(x => x.ID == qh.ID);
            if (FindQh == null)
            {
                return false;
            }
            else
            {
                FindQh.tenQuan_Huyen = qh.tenQuan_Huyen;
                FindQh.trangThai = qh.trangThai;

                _Context.QuanHuyens.Update(FindQh);
                _Context.SaveChanges();
                return true;
            }
        }
        public List<Quan_Huyen> GetAllQuanHuyen()
        {
            return _Context.QuanHuyens.Select(x => new Quan_Huyen()
            {
                ID = x.ID,
                tenQuan_Huyen = x.tenQuan_Huyen,
                trangThai = x.trangThai
            }).ToList();
        }

        public Quan_Huyen GetQuanHuyen(int IdQuanHuyen)
        {
            return _Context.QuanHuyens.Find(IdQuanHuyen);
        }
    }
}