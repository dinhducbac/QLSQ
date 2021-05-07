using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QLSQ.Application.Catalog.BoPhan;
using QLSQ.Application.Catalog.ChucVu;
using QLSQ.Application.Catalog.HeSoLuongTheoQuanHam;
using QLSQ.Application.Catalog.HeSoPhuCapTHeoChucVu;
using QLSQ.Application.Catalog.LuongCoBan;
using QLSQ.Application.Catalog.New;
using QLSQ.Application.Catalog.NewImage;
using QLSQ.Application.Catalog.QLChucVu;
using QLSQ.Application.Catalog.QLCongTac;
using QLSQ.Application.Catalog.QLDangVien;
using QLSQ.Application.Catalog.QLGiaDinhSQ;
using QLSQ.Application.Catalog.QLKhenThuongKiLuat;
using QLSQ.Application.Catalog.QLLuong;
using QLSQ.Application.Catalog.QLNghiPhep;
using QLSQ.Application.Catalog.QLQuanHam;
using QLSQ.Application.Catalog.QLQuaTrinhDaoTao;
using QLSQ.Application.Catalog.QuanHam;
using QLSQ.Application.Catalog.SiQuan;
using QLSQ.Application.Catalog.SiQuanImage;
using QLSQ.Application.Catalog.SiQuans;
using QLSQ.Application.Common;
using QLSQ.Application.System.Roles;
using QLSQ.Application.System.Users;
using QLSQ.Data.EF;
using QLSQ.Data.Entities;
using QLSQ.Utilities.Contants;
using QLSQ.ViewModel.System.Users;

namespace QLSQ.BackEndAPI
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
            services.AddMvc();

            services.AddDbContext<QL_SiQuanDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(SystemContants.MainConnectionString)));

            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<QL_SiQuanDBContext>()
                .AddDefaultTokenProviders();


            services.AddTransient<IPublicSiQuanServices, PublicSiQuanServices>();
            services.AddTransient<IManageSiQuanServices, ManageSiQuanServices>();
            services.AddTransient<IStorageServices, FileStorageServices>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRolesService, RolesService>();
            services.AddTransient<IQLDangVienServices, QLDangVienServices>();
            services.AddTransient<IQLCongTacServices, QLCongTacServices>();
            services.AddTransient<IQLLuongServices, QLLuongServices>();
            services.AddTransient<IQuanHamServices, QuanHamServices>();
            services.AddTransient<IHeSoLuongTheoQuanHamServices, HeSoLuongTheoQuanHamServices>();
            services.AddTransient<IBoPhanServices, BoPhanServices>();
            services.AddTransient<IChucVuServices, ChucVuServices>();
            services.AddTransient<IHeSoPhuCapTheoChucVuServices, HeSoPhuCapTheoChucVuServices>();
            services.AddTransient<IQLChucVuServices, QLChucVuServices>();
            services.AddTransient<ILuongCoBanServices, LuongCoBanServices>();
            services.AddTransient<IQLNghiPhepServices, QLNghiPhepServices>();
            services.AddTransient<IQLKhenThuongKiLuatServices, QLKhenThuongKiLuatServices>();
            services.AddTransient<IQLQuaTrinhDaoTaoServices, QLQuaTrinhDaoTaoServices>();
            services.AddTransient<IQLGiaDinhSQServices, QLGiaDinhServices>();
            services.AddTransient<ISiQuanImageServices, SiQuanImageServices>();
            services.AddTransient<IQLQuanHamServices, QLQuanHamServices>();
            services.AddTransient<INewImageStorageService, NewImageStorageServices>();
            services.AddTransient<INewImageServices, NewImageServices>();
            services.AddTransient<INewServices, NewServices>();
            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());
            //services.AddControllersWithViews()
            //.AddNewtonsoftJson(options =>
            //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger QLSQ", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Enter Bearer [space] and your token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement( new OpenApiSecurityRequirement() 
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
            string issuer = Configuration.GetValue<string>("Token:Issuer");
            string signingKey = Configuration.GetValue<string>("Token:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option=> {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });
            //declare DI
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
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger QLSQ V1");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
