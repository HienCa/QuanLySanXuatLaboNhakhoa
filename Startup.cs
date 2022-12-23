using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuanLySanXuat.Entities;
using QuanLySanXuat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanXuat
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
            services.AddTransient<SendMailService>();
            services.AddOptions();
            var mailsettings = Configuration.GetSection("MailSettings");
            services.Configure<MailSettings>(mailsettings);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Home/DangNhap";
                    options.Cookie.Name = "HienCaCookie";
                });
            services.AddMvc();
            services.AddControllersWithViews();
            //services.AddDbContext<ProductionManagementSoftwareContext>();
            //services.AddRazorPages();
            services.AddDbContext<ProductionManagementSoftwareContext>(option => option.UseSqlServer(Configuration.GetConnectionString("MyConnectionString")));
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
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                //pattern: "{controller=PersonalInformationManament}/{action=PersonalBankManament}/{id?}");
                //pattern: "{controller=Home}/{action=Index}/{id?}");
                pattern: "{controller=Home}/{action=DangNhap}/{id?}");

                //pattern: "{controller=Admin}/{action=Index}/{id?}");
                //pattern: "{controller=QuanLyTonKho}/{action=QuanLyNhapKho}/{id?}");
                //pattern: "{controller=Chitietnganhangkh}/{action=Index}/{id?}");

                //pattern: "{controller=Tosanxuat}/{action=Index}/{id?}");




                endpoints.MapRazorPages();
                endpoints.MapGet("/TestSendMail", async(context)=>
                {
                    var message = await MailUtils.MailUtils.SendMail("dtny050601@gmail.com", "dtny050601@gmail.com", "TEST", "Xin chào Như Ý", "dtny050601@gmail.com", "ycfbcfyjtyzlammz");
                    await context.Response.WriteAsync(message);
                });
                //endpoints.MapGet("/TestSenMailService", async (context) =>
                //{
                //    var sendMailService = context.RequestServices.GetService<SendMailService>();
                //    var mailContent = new MailContent();
                //    mailContent.To = "dtny050601@gmail.com";
                //    mailContent.Subject = "Xác nhận email";
                //    mailContent.Body = "<h1>TEST</h1><i>Hello HienCa</i>";

                //     var kq = sendMailService.SendMail(mailContent);

                //    await context.Response.WriteAsync(kq);
                //});
            });
        }
    }
}
