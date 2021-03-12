using System;
using Ketomaner.Data;
using Ketomaner.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Ketomaner.Areas.Identity.IdentityHostingStartup))]
namespace Ketomaner.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<KetomanerContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("KetomanerContextConnection")));

                services.AddDefaultIdentity<Users>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<KetomanerContext>();
            });
        }
    }
}