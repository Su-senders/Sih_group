using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Sih.Application.Interfaces.Administration;
using Sih.Application.Interfaces.Gestion;
using Sih.Application.Interfaces.Localisation;
using Sih.Application.Interfaces.Pelerins;
using Sih.Application.Services.Administration;
using Sih.Application.Services.Gestion;
using Sih.Application.Services.Localisation;
using Sih.Application.Services.Pelerins;
using Sih.Domain.Interfaces;
using Sih.Domain.Interfaces.Administration;
using Sih.Domain.Interfaces.Gestion;
using Sih.Domain.Interfaces.Localisation;
using Sih.Domain.Interfaces.Pelerins;
using Sih.Persistence.Repositories;
using Sih.Persistence.Repositories.Administration;
using Sih.Persistence.Repositories.Gestion;
using Sih.Persistence.Repositories.Localisation;
using Sih.Persistence.Repositories.Pelerins;
using Sih.Web.Ressources;
using System;
using System.Globalization;
using System.Reflection;

namespace Sih.Web
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
            services.AddControllersWithViews();
            //Debut ---- Injection des Interfaces
            //
            //les génériques
            services.AddSingleton(typeof(IGenericDomain<>), typeof(GenericRepository<>));
            //
            //Administration
            //UserEntity est déjà géré par Identity
            services.AddSingleton<INotificationsApplication, NotificationsApplication>();
            services.AddSingleton<INotificationsDomain, NotificationsRepository>();
            //
            //
            //Enums
            //RAS
            //
            //
            //Gestion
            services.AddSingleton<IAvionApplication, AvionApplication>();
            services.AddSingleton<IAvionDomain, AvionRepository>();
            //
            services.AddSingleton<IInscriptionApplication, InscriptionApplication>();
            services.AddSingleton<IInscriptionDomain, InscriptionRepository>();
            //
            services.AddSingleton<IPaiementApplication, PaiementApplication>();
            services.AddSingleton<IPaiementDomain, PaiementRepository>();
            //
            services.AddSingleton<IPiecesJointeApplication, PiecesJointeApplication>();
            services.AddSingleton<IPiecesJointesDomain, PieceJointeRepository>();

            services.AddSingleton<IPieceTypeApplication, PiecesTypeApplication>();
            services.AddSingleton<IPiecesTypesDomain, PiecesTypeRepository>();
            //
            services.AddSingleton<IVolApplication, VolApplication>();
            services.AddSingleton<IVolDomain, VolRepository>();
            //
            services.AddSingleton<IVoyageApplication, VoyageApplication>();
            services.AddSingleton<IVoyageDomain, VoyageRepository>();
            //
            //
            //Localisation
            services.AddSingleton<IDepartureTownApplication, DepartureTownApplication>();
            services.AddSingleton<IDepartureTownDomain, DepartureTownRepository>();
            //
            services.AddSingleton<IRegionApplication, RegionApplication>();
            services.AddSingleton<IRegionDomain, RegionRepository>();
            //
            services.AddSingleton<IVilleApplication, VilleApplication>();
            services.AddSingleton<IVilleDomain, VilleRepository>();
            //
            //
            //Pelerins
            services.AddSingleton<IAgreementApplication, AgreementApplication>();
            services.AddSingleton<IAgreementDomain, AgreementRepository>();
            //
            services.AddSingleton<IUsagerApplication, UsagerApplication>();
            services.AddSingleton<IUsagerDamain, UsagerRepository>();
            //
            services.AddSingleton<IHadjApplication, HadjApplication>();
            services.AddSingleton<IHadjDomain, HadjRepositoty>();
            //
            services.AddSingleton<ISocieteApplication, SocieteApplication>();
            services.AddSingleton<ISocieteDomain, SocieteRepository>();
            //
            services.AddSingleton<IEncadreurApplication, EncadreurApplication>();
            services.AddSingleton<IEncadreurDomain, EncadreurRepository>();
            //
            //Debut ---- Ajout du service de Globalisation & Localisation 1/2
            //
            services.AddLocalization(options => options.ResourcesPath = "Ressources");
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(ApplicationRessource).GetTypeInfo().Assembly.FullName);
                        return factory.Create("ApplicationRessource", assemblyName.Name);
                    };
                });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                 {
                        new CultureInfo("fr"),
                        new CultureInfo("en")
                     };
                options.DefaultRequestCulture = new RequestCulture("fr");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            //
            //Fin ---- Ajout du service de Globalisation & Localisation 1/2

            //Active la compilation des pages razor pendant l'exécution
            //prerequis: Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
            services.AddRazorPages().AddRazorRuntimeCompilation();


            // Début configuration des services de sessions 1/2
            //
            //
            services.AddDistributedMemoryCache();

            services.AddSession(Options =>
            {
                Options.IdleTimeout = TimeSpan.FromSeconds(60);
                Options.Cookie.HttpOnly = true;
                Options.Cookie.IsEssential = true;
            });
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


            //Ajout du service de Globalisation & Localisation 2/2
            var requestLocalizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(requestLocalizationOptions.Value);

            app.UseAuthentication(); //Doit être appelé après  app.UseRouting(); et avant app.UseAuthorization(); 

            app.UseAuthorization();

            // Début configuration des services de sessions 2/2
            //
            app.UseSession();
            //
            // Fin de configuration de service de sessions 

            app.UseEndpoints(endpoints =>
            {
                //Pour faire fonctionner les zones
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //Fait fonctionner les pages razors de identity
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
