using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuanLySanXuat.Areas.Identity.Data;
using QuanLySanXuat.Data;

[assembly: HostingStartup(typeof(QuanLySanXuat.Areas.Identity.IdentityHostingStartup))]
namespace QuanLySanXuat.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<QuanLySanXuatContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("QuanLySanXuatContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(
                    options => 
                    { 
                        options.SignIn.RequireConfirmedAccount = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireLowercase = false;
                    }

                )
                    .AddEntityFrameworkStores<QuanLySanXuatContext>();
            });
        }
    }
}