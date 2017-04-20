using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Data
{
    public class LogRepository : ILogRepository
    {
#if DEBUG
        private static string REPOSITORYURL = "http://localhost:49752/api/";
#else
        //Real URL
        private static string REPOSITORYURL = "http://localhost:49752/api/";
#endif
        private RestClient _restClient;

        public LogRepository()
        {
            _restClient = new RestClient(REPOSITORYURL);
        }

        public async Task<string> Log(JObject logEntry)
        {
            var request = new RestRequest("log", Method.POST);

            request.AddParameter("Application/Json", logEntry, ParameterType.RequestBody);
            var result = await _restClient.ExecuteTaskAsync(request);
            return result.StatusCode.ToString();
        }
    }
}