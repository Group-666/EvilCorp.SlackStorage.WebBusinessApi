using EvilCorp.SlackStorage.WebBusinessApi.Application;
using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using StructureMap;
using System.Diagnostics;

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