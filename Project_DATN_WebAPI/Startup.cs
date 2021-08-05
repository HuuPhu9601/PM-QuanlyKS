using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project_DATN.Data.EF.DBContext;
using Project_DATN.Services.IServices;
using Project_DATN.Services.IServices.ManhIServices;
using Project_DATN.Services.Services;
using Project_DATN.Services.Services.ManhServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Project_DATN.Services.IServices.PhuIServices;
using Project_DATN.Services.Services.PhuServices;
using Project_DATN.Services.IServices.HiepIServices;
using Project_DATN.Services.IServices.PhamVietIServices;
using Project_DATN.Services.Services.HiepServices;
using Project_DATN.Services.Services.PhamVietServices;
using FluentValidation.AspNetCore;
using Project_DATN.Services.Models;

namespace Project_DATN_WebAPI
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
            //su dung fluent validattion (addfluentvaliatetion)
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CosoRequestValidator>());

            services.AddScoped<IGiaoCaService, GiaoCaService>();
            services.AddScoped<IHoaDonService, HoaDonService>();
            services.AddScoped<IHoaDonChiTietService, HoaDonChiTietService>();
            services.AddScoped<IGiaoDichService, GiaoDichService>();
            services.AddScoped<IKhachHangService, KhachHangService>();
            services.AddScoped<ITaiKhoanService, TaiKhoanService>();
            services.AddScoped<IQuyenHanService, QuyenHanService>();
            services.AddScoped<IDichVuService, DichVuService>();
            services.AddScoped<ILoaiDichVuService, LoaiDichVuService>();
            services.AddScoped<ILuongService, LuongService>();
            services.AddScoped<IQuanhuyenService, QuanHuyenService>();
            services.AddScoped<ITinhThanhPhoService, TinhThanhPhoService>();
            services.AddTransient<ILoaiPhongService, LoaiPhongService>();
            services.AddTransient<ICosoService, CosoService>();
            services.AddTransient<IAutoRenderRoomService, AutoRenderRoomService>();
            services.AddTransient<ILauService, LauService>();
            services.AddTransient<IPhongService, PhongService>();
            services.AddScoped<TaiKhoanNganHangIService, TaiKhoanNganHangService>();

            services.AddDbContext<DB_Context>(c => c.UseSqlServer(Configuration.GetConnectionString("DATN")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
