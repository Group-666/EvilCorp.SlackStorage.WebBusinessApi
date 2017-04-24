using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using StructureMap;
using EvilCorp.SlackStorage.WebBusinessApi.WebHost.IoC;
using System.Diagnostics;

namespace EvilCorp.SlackStorage.WebBusinessApi.WebHost
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