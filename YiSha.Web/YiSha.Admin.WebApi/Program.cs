using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using AspNetCoreWeChatCode2Session;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace YiSha.Admin.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseUrls("http://*:5100")
                   .UseStartup<Startup>()
                   .ConfigureLogging(logging =>
                   {
                       logging.ClearProviders();
                       logging.SetMinimumLevel(LogLevel.Trace);
                   }).UseNLog();
    }
}
