using System;
using CarsFactory.Areas.Identity.Data;
using CarsFactory.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CarsFactory.Areas.Identity.IdentityHostingStartup))]
namespace CarsFactory.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CarsFactoryContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CarsFactoryContextConnection")));

                services.AddDefaultIdentity<CarsFactoryUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CarsFactoryContext>();
            });
        }
    }
}