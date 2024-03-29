using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using QLSQ.ViewModel.System.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using QLSQ.ApiIntergration;
using QLSQ.ViewModel.Catalogs.SiQuan;

namespace QLSQ.AdminApp
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
            services.AddControllersWithViews()
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>())
                    .AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<CreateUserRequestValidator>())
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateUserRequestValidator>())
                    .AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<SiQuanCreateRequestValidator>())
                    .AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<SiQuanUpdateRequestValidator>());
            services.AddHttpClient();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/User/Login";
                options.AccessDeniedPath = "/User/Login";
            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<IRolesApiClient, RolesApiClient>();
            services.AddTransient<ISiQuanApiClient, SiQuanApiClient>();
            services.AddTransient<IQLDangVienAPIClient, QLDangVienApiClient>();
            services.AddTransient<IQLCongTacApiClient,QLCongTacApiClient>();
            services.AddTransient<IQLLuongApiClient, QLLuongApiClient>();
            services.AddTransient<IQuanHamApiClient, QuanHamApiClient>();
            services.AddTransient<IHeSoLuongTheoQuanHamApiClient, HeSoLuongTheoQuanHamApiClient>();
            services.AddTransient<IBoPhanApiClient, BoPhanAPIClient>();
            services.AddTransient<IChucVuApiClient, ChucVuApiClient>();
            services.AddTransient<IHeSoPhuCapTheoChucVuApiClient, HeSoPhuCapTheoChucVuApiClient>();
            services.AddTransient<IQLChucVuApiClient, QLChucVuApiClient>();
            services.AddTransient<ILuongCoBanApiClient, LuongCoBanApiClient>();
            services.AddTransient<IQLNghiPhepApiClient, QLNghiPhepApiClient>();
            services.AddTransient<IQLKhenThuongKiLuatApiClient, QLKhenThuongKiLuatApiClient>();
            services.AddTransient<IQLQuaTrinhDaoTaoApiClient, QLQuaTrinhDaoTaoApiClient>();
            services.AddTransient<IQLGiaDinhApiClient, QLGiaDinhApiClient>();
            services.AddTransient<ISiQuanImageApiClient, SiQuanImageApiClient>();
            services.AddTransient<IQLQuanHamApiClient, QLQuanHamApiClient>();
            services.AddTransient<INewApiClient, NewApiClient>();
            services.AddTransient<INewImageApiClient, NewImageApiClient>();
            services.AddTransient<INewCatetoryApiClient, NewCatetoryApiClient>();
            IMvcBuilder builder = services.AddRazorPages();
            var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT");
#if DEBUG
            if (enviroment == Environments.Development)
            {
                builder.AddRazorRuntimeCompilation();
            }
#endif
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
