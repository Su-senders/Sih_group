using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sih.Entities.Administration;
using Sih.Persistence.Configurations;

[assembly: HostingStartup(typeof(Sih.Web.Areas.Identity.IdentityHostingStartup))]
namespace Sih.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SihDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddIdentity<UserEntity, IdentityRole>()
                        .AddEntityFrameworkStores<SihDbContext>()
                        .AddDefaultUI()
                        .AddDefaultTokenProviders();

                /*
                    Le code suivant utilise un filtre d’autorisation, la définition de la stratégie de secours utilise le routage du
                    point determinaison.La définition de la stratégie de secours est la méthodere commandée pour exiger que tous
                    les utilisateurs soient authentifiés.
                    Ajoutez AllowAnonymous aux Index pages et Privacy afin que les utilisateurs anonymes puissent obtenir des
                    informations sur le site avant de s’inscrire:
                
                This will add a new policy to the ASP.NET Core MVC Application that every method needs an authenticated user, 
                unless we define it as [AllowAnonymous]
                 */
                services.AddControllers(config =>
                {
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                });
            });
        }
    }
}