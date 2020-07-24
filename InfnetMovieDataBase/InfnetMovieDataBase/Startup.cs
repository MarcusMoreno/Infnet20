using InfnetMovieDataBase.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InfnetMovieDataBase
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            #region repository
            services.AddSingleton<IAtorRepository, AtorRepository>();
            services.AddSingleton<IFilmeRepository, FilmeRepository>();
            services.AddSingleton<IGeneroRepository, GeneroRepository>();
            services.AddSingleton<IFilmeAtorRepository, FilmeAtorRepository>();
            services.AddSingleton<IFilmeGeneroRepository, FilmeGeneroRepository>();
            #endregion


            services
            .AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            services.AddResponseCompression();

            services
             .AddCors(o => o.AddPolicy("dashboard", builder =>
             {
                 builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
             }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app
           .UseResponseCompression()
           .UseAuthentication()
           .UseMvc();

        }
    }
}
