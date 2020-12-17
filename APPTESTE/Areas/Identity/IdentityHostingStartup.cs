using System;
using APPTESTE.Areas.Identity.Data;
using APPTESTE.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(APPTESTE.Areas.Identity.IdentityHostingStartup))]
namespace APPTESTE.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UsuarioDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UsuarioDBContextConnection")));

                services.AddDefaultIdentity<Usuario>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    
                })
                    .AddEntityFrameworkStores<UsuarioDBContext>();
            });
        }
    }
}