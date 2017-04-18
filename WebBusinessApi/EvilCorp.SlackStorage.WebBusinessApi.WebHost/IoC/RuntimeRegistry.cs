﻿using EvilCorp.SlackStorage.WebBusinessApi.Business;
using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using StructureMap;

namespace EvilCorp.SlackStorage.WebBusinessApi.WebHost.IoC
{
    public class RuntimeRegistry : Registry
    {
        public RuntimeRegistry()
        {
            Scan(x =>
            {
                x.AssembliesAndExecutablesFromApplicationBaseDirectory();
                x.WithDefaultConventions();
            });
            For<IExceptionHandler>().Singleton().Use<ExceptionHandler>();
        }
    }
}