using EvilCorp.SlackStorage.WebApi.Business;
using EvilCorp.SlackStorage.WebApi.Data;
using EvilCorp.SlackStorage.WebApi.Domain.Contracts;
using StructureMap;

namespace EvilCorp.SlackStorage.WebApi.WebHost.IoC
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
            For<ILogRepository>().Singleton().Use<LogRepository>();
            For<IClientDataRespository>().Singleton().Use<ClientDataRespository>();
            For<IExceptionHandler>().Singleton().Use<ExceptionHandler>();
        }
    }
}