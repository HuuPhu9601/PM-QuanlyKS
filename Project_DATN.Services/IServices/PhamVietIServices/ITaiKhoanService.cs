using System.Collections.Generic;
using System.Threading.Tasks;
using Project_DATN.Data.EF.Entities;

namespace Project_DATN.Services.IServices.PhamVietIServices
{
   public interface ITaiKhoanService
   {
       List<TaiKhoan> GetAllTaiKhoan();
       TaiKhoan FindById(int id);
       Task<TaiKhoan> Add(TaiKhoan tk);
       Task<TaiKhoan> Edit(TaiKhoan tk);
       Task<int> Delete(int id);
   }
}
