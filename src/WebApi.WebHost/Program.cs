using Microsoft.AspNetCore.Hosting;
using StructureMap;
using System.IO;
using EvilCorp.SlackStorage.WebApi.WebHost.IoC;

namespace EvilCorp.SlackStorage.WebApi.WebHost
{
    public class Program
    {
        public static Container Container = new Container(new RuntimeRegistry());

        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();
            //Debug.WriteLine(Container.WhatDoIHave());

            host.Run();
        }
    }
}