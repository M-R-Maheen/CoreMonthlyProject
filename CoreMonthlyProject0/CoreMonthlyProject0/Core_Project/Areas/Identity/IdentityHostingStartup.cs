using System;
using Core_Project.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Core_Project.Areas.Identity.IdentityHostingStartup))]
namespace Core_Project.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Core_ProjectContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Core_ProjectContextConnection")));

                //    services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //.AddEntityFrameworkStores<Core_ProjectContext>();
            });
        }
    }
}