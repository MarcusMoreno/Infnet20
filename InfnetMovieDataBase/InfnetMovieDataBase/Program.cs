using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace InfnetMovieDataBase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
              WebHost.CreateDefaultBuilder(args)
             .UseStartup<Startup>()
             .ConfigureKestrel(o =>
             { 
                 o.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(7); 
             });
    }
}
