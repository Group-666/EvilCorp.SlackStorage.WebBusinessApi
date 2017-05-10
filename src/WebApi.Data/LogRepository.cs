using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using WebApi.Domain.Contracts;

namespace WebApi.Data
{
    public class LogRepository : ILogRepository
    {
#if DEBUG
        private static string REPOSITORYURL = "http://localhost:5050/api/log";
#else
        //Real URL
        private static string REPOSITORYURL = "http://localhost:5050/api/log";
#endif
        private readonly RestClient _restClient;

        public LogRepository()
        {
            _restClient = new RestClient(REPOSITORYURL);
        }

        public async Task<string> Log(JObject logEntry)
        {
            var request = new RestRequest(Method.POST);

            request.AddParameter("Application/Json", logEntry, ParameterType.RequestBody);
            var result = await _restClient.ExecuteTaskAsync(request);
            return result.StatusCode.ToString();
        }
    }
}