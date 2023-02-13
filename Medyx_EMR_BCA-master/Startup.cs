using Medyx.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.Helpers;
using Medyx_EMR_BCA.ApiAssets.Middlewares;
using Medyx_EMR_BCA.ApiAssets.Models;
using Medyx_EMR_BCA.ApiAssets.Models.Configure;
using Medyx_EMR_BCA.ApiAssets.Repository;
using Medyx_EMR_BCA.ApiAssets.Services;
using Medyx_EMR_BCA.Models.DBConText;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MongGoDBConnectWeb
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
            DatabaseSettings settings = Configuration.GetSection("Medyx_EMR_BCA_SQLConnectionString").Get<DatabaseSettings>();
            services.AddSingleton(settings);
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(30));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(120);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            }).AddJsonOptions(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddMemoryCache();
            //services.AddSingleton<IHostingEnvironment>(env);
            services.Configure<PrintSetting>(Configuration.GetSection("PrintSetting"));
            services.Configure<StorageSetting>(Configuration.GetSection("StorageSetting"));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Add scope
            services.AddScoped<UploadFileRespository>();
            services.AddScoped<BenhAnClsService>();
            services.AddScoped<BenhAnService>();
            services.AddScoped<BenhAnCpmService>();
            services.AddScoped<BenhAnFilePhiCauTrucService>();
            services.AddScoped<BenhAnKhoaDieuTriService>();
            services.AddScoped<BenhAnToDieuTriService>();
            services.AddScoped<BenhAnThuocTayYService>();
            services.AddScoped<BenhAnThuocYhctService>();
            services.AddScoped<BenhAnThuocYhctCService>();
            services.AddScoped<BenhanPhauThuatPhieuKhamGayMeTruocMoService>();
            services.AddScoped<BenhAnPhauThuatDuyetMoService>();
            services.AddScoped<BenhanPhauThuatPhieuPtttService>();
            services.AddScoped<BenhAnPhieuChamSocService>();
            services.AddScoped<BenhAnPhieuXetNghiemService>();
            services.AddScoped<BenhAnPhauThuatService>();
            services.AddScoped<DmbaLoaiTaiLieuService>();
            services.AddScoped<BenhAnThongTinTuVongService>();
            services.AddScoped<BenhAnThuocThuPhanUngService>();
            services.AddScoped<BenhAnTheoDoiTruyenDichService>();
            services.AddScoped<BenhAnTheoDoiTruyenMauService>();
            services.AddScoped<BenhAnTheoDoiTruyenMauCService>();
            services.AddScoped<BenhAnTaiBienPtttService>();
            services.AddScoped<BenhAnPhacDoDtService>();
            services.AddScoped<BenhAnTtvltlDotDieuTriService>();
            services.AddScoped<BenhAnTtvltlThuchienService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHttpContextAccessor accessor, IOptions<StorageSetting> options)
        {

            // Trick Optimize
            Task.Run(() =>
            {
                using (var dbContext = new MedyxDbContext())
                {
                    var model = dbContext.Model; //force the model creation
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // add cache
            //app.Use(async (context, next) =>
            //	{
            //		await CacheResponseHeaderHelper.AddCache(context, next);
            //	}
            //);

            app.UseMiddleware<ResponseMiddleware>();

            app.UseExceptionHandler(errorApp =>
            {
                ErrorResponseHelper.Error(errorApp, env.IsProduction());
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(env.ContentRootPath, "Storage/Public")),
                RequestPath = "/StaticFiles"
            });

            if (options.Value != null && !String.IsNullOrEmpty(options.Value.Location))
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(options.Value.Location, "Storage/HSBA")),
                    RequestPath = "/Storage/HSBA"
                });
            }
            else
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Storage/HSBA")),
                    RequestPath = "/Storage/HSBA"
                });
            }


            app.UseCookiePolicy();

            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "HSBADS",
                   template: "HSBADS/{*url}",
                   defaults: new { controller = "Login", action = "Login" });
                routes.MapRoute(
                   name: "HSBALT",
                   template: "HSBALT/{*url}",
                   defaults: new { controller = "Login", action = "Login" });
                routes.MapRoute(
                    name: "HSBAPH",
                    template: "HSBAPH/{*url}",
                    defaults: new { controller = "Login", action = "Login" });
                //routes.MapRoute(
                //   name: "DMNhanVien",
                //   template: "{controller=DMNhanVien}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}
