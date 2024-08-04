using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MyRestApi
{
    public class Program
    {
        // MAIN METHOD ENTRY POINT
        public static void Main(string[] args)
        {
            // CREATE AND RUN HOST
            CreateHostBuilder(args).Build().Run();
        }

        // CONFIGURE AND RETURN HOST BUILDER
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            // SETUP HOST DEFAULTS
            Host.CreateDefaultBuilder(args)
                // CONFIGURE WEB HOST
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // USE STARTUP CLASS
                    webBuilder.UseStartup<Startup>();
                });
    }
}
