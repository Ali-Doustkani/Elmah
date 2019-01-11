using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Elmah
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((context, builder) =>
                {
                    builder.AddElmahIo(options =>
                    {
                        options.ApiKey = "API-Key";
                        options.LogId = Guid.Parse("LOG-ID");
                    });
                })
                .UseStartup<Startup>();
    }
}
