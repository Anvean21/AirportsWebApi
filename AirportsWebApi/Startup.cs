using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using Airport.Infrastructure.Data;
using Airport.Domain.Core.Intefaces;
using Airport.Infastructure.Bussines;
using AirportsWebApi.Automapper;
using Airport.Infastructure.Bussines.Interfaces;
using Airport.Infastructure.Bussines.Services;

namespace AirportsWebApi
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

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AirportContext>(options =>
                options.UseSqlServer(connection));
            services.AddCors(); // добавляем сервисы CORS

            services
                .AddScoped(typeof(IRepository<>), typeof(EFRepository<>))
                .AddScoped<DbContext, AirportContext>()
                .AddTransient<IFlightService, FlightService>()
                .AddTransient<ICountryService, CountryService>()
                .AddTransient<ICityService, CityService>()
                .AddTransient<IAirportService, AirportService>()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddAutoMapper(cfg => cfg.AddProfile<MainProfile>())
                .AddScoped<IMapper, EntityMapper>()
                .AddReact();

            services.AddMvc();
            // Make sure a JS engine is registered, or you will get an error!
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
              .AddChakraCore();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AirportsWebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AirportsWebApi v1"));
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors(builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            app.UseReact(config =>
            {
                // If you want to use server-side rendering of React components,
                // add all the necessary JavaScript files here. This includes
                // your components as well as all of their dependencies.
                // See http://reactjs.net/ for more information. Example:
                //config
                //    .AddScript("~/js/First.jsx")
                //    .AddScript("~/js/Second.jsx");

                // If you use an external build too (for example, Babel, Webpack,
                // Browserify or Gulp), you can improve performance by disabling
                // ReactJS.NET's version of Babel and loading the pre-transpiled
                // scripts. Example:
                //config
                //    .SetLoadBabel(false)
                //    .AddScriptWithoutTransform("~/Scripts/bundle.server.js");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
