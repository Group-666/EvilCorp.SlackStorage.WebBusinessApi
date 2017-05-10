using System.IO;
using Microsoft.AspNetCore.Hosting;
using StructureMap;
using WebApi.WebHost.IoC;

namespace WebApi.WebHost
{
    public class Program
    {
        public static Container Container = new Container(new RuntimeRegistry());
        public static void Main(string[] args)
        {

            var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration() //Suspicious 
                    .UseStartup<Startup>()
                    .UseApplicationInsights()
                    .UseUrls("http://0.0.0.0:8080")
                    .Build();

            host.Run();
        }
    }
}
