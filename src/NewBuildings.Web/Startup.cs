using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewBuildings.BootstrapApp;
using NewBuildings.BusinessLogic.Services;
using NewBuildings.Data;
using NewBuildings.Data.Abstract;
using NewBuildings.Data.Repositories;

namespace NewBuildings.Web
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
            var connectionString = Configuration.GetConnectionString("Default");
            services.AddScoped<IDbConnectionFactory>((service) => new MsSqlConnectionFactory(connectionString));

            ConfigureDI(services);
            BootstrapApp(connectionString);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        private static void ConfigureDI(IServiceCollection services)
        {
            services.AddScoped<IFlatRepository, FlatRepository>();
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();

            services.AddScoped<FlatService>();
        }

        private static void BootstrapApp(string connectionString)
        {
            var appBootstraper = new AppBootstraper(new MsSqlConnectionFactory(connectionString));
            appBootstraper.Bootstrap();
        }      

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
