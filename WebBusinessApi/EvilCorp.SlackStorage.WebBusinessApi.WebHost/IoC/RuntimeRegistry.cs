using EvilCorp.SlackStorage.WebBusinessApi.Business;
using EvilCorp.SlackStorage.WebBusinessApi.Data;
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
            For<ILogRepository>().Singleton().Use<ILogRepository>();
            For<IClientDataRespository>().Singleton().Use<ClientDataRespository>();
            For<IExceptionHandler>().Singleton().Use<ExceptionHandler>();
        }
    }
}