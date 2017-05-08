using StructureMap;
using WebApi.Business;
using WebApi.Data;
using WebApi.Domain.Contracts;

namespace WebApi.WebHost.IoC
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
            For<IClientDataRepository>().Singleton().Use<ClientDataRepository>();
            For<IExceptionHandler>().Singleton().Use<ExceptionHandler>();
            For<IAccountRepository>().Singleton().Use<AccountRepository>();
            For<ILogRepository>().Singleton().Use<LogRepository>();
        }
    }
}