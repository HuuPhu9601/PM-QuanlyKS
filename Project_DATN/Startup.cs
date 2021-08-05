using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Services.IServices;
using Project_DATN.Services.Services;
using Project_DATN.Services.IServices.ManhIServices;
using Project_DATN.Services.Services.ManhServices;
using Project_DATN.Services.IServices.HiepIServices;
using Project_DATN.Services.IServices.PhamVietIServices;
using Project_DATN.Services.Services.HiepServices;
using Project_DATN.Services.IServices.PhuIServices;
using Project_DATN.Services.Services.PhamVietServices;
using Project_DATN.Services.Services.PhuServices;
using FluentValidation.AspNetCore;
using Project_DATN.Services.Models;

namespace Project_DATN
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CosoRequestValidator>());

            services.AddScoped<IGiaoCaService, GiaoCaService>();
            services.AddScoped<IHoaDonService, HoaDonService>();
            services.AddScoped<IHoaDonChiTietService, HoaDonChiTietService>();
            services.AddScoped<IGiaoDichService, GiaoDichService>();
            services.AddScoped<IKhachHangService, KhachHangService>();
            services.AddScoped<IBookingServices, BookingRoomServices>();
            services.AddScoped<ITaiKhoanService, TaiKhoanService>();
            services.AddScoped<IQuyenHanService, QuyenHanService>();
            services.AddScoped<IDichVuService, DichVuService>();
            services.AddScoped<ILoaiDichVuService, LoaiDichVuService>();
            services.AddScoped<TaiKhoanNganHangIService, TaiKhoanNganHangService>();
            services.AddScoped<ICheckInCheckOutService, CheckInCheckOutService>();
            services.AddScoped<ILuongService, LuongService>();
            services.AddScoped<IQuanhuyenService, QuanHuyenService>();
            services.AddScoped<ITinhThanhPhoService, TinhThanhPhoService>();
            services.AddScoped<ILoaiPhongService, LoaiPhongService>();
            services.AddScoped<IPhongService, PhongService>();
            services.AddScoped<ICosoService, CosoService>();
            services.AddControllersWithViews();
            services.AddDbContext<DB_Context>(c => c.UseSqlServer(Configuration.GetConnectionString("DATN")));

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}");
            });
        }
    }
}
