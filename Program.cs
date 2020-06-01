using System;
using Fivet.Dao;
using Fivet.ZeroIce;
using Fivet.ZeroIce.model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Fivet.Server
{
    class Program
    {
       public static void Main(string[] args) {

           CreateHostBuilder(args).Build().Run();

       }

        public static IHostBuilder CreateHostBuilder(string[] args) {
            
            return Host
                .CreateDefaultBuilder(args)
                .UseEnvironment("Development")
                .ConfigureLogging(logging => 
                {
                    logging.ClearProviders();
                    logging.AddConsole(options =>
                    {
                        options.IncludeScopes = true;
                        options.TimestampFormat = "[yyyy-MM-dd HH:mm:ss.fff] ";
                        options.DisableColors = false;
                    });
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseConsoleLifetime()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<TheSystemDisp_, TheSystemImpl>();
                    services.AddSingleton<ContratosDisp_, ContratosImpl>();
                    services.AddDbContext<FivetContext>();
                    services.AddHostedService<FivetService>();
                    services.AddLogging();
                    services.Configure<HostOptions>(options =>
                    {
                        options.ShutdownTimeout = System.TimeSpan.FromSeconds(15);
                    });
                });  

                

        }

    }
}
