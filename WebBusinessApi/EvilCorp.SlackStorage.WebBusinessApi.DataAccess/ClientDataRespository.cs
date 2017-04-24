using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using EvilCorp.SlackStorage.WebBusinessApi.Domain.Entities;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.Data
{
    public class ClientDataRespository : IClientDataRespository
    {
#if DEBUG
        private static string REPOSITORYURL = "http://localhost:49752/api/";
#else
        //Real URL
        private static string REPOSITORYURL = "http://localhost/api/storage";
#endif
        private readonly ILogger _logger;
        private RestClient _restClient;

        public ClientDataRespository(ILogger logger)
        {
            _restClient = new RestClient(REPOSITORYURL);
            _logger = logger;
        }

        public async Task<string> GetAll(string userId)
        {
            var request = new RestRequest("storage/" + userId, Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result);
        }

        public async Task<string> GetOne(string userId, string dataStoreId)
        {
            var request = new RestRequest("storage/" + userId + "/" + dataStoreId, Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result);
        }

        public async Task<string> GetOneElement(string userId, string dataStoreId, string elementId)
        {
            var request = new RestRequest("storage/" + userId + "/" + dataStoreId + "/data/" + elementId, Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result);
        }

        public async Task<string> GetAllElements(string userId, string dataStoreId)
        {
            var request = new RestRequest("storage/" + userId + "/" + dataStoreId + "/data", Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result);
        }

        public async Task<HttpStatusCode> Create(string userId, string dataStoreName)
        {
            var request = new RestRequest("storage/" + userId, Method.POST);
            request.AddParameter("Application/Json", dataStoreName, ParameterType.RequestBody);

            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnError(result);
        }

        public async Task<HttpStatusCode> Post(string userId, string dataStoreId, string data)
        {
            var request = new RestRequest("storage/" + userId + "/" + dataStoreId, Method.POST);
            request.AddParameter("Application/Json", data, ParameterType.RequestBody);

            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnError(result);
        }

        public async Task<HttpStatusCode> DeleteAll(string userId)
        {
            var request = new RestRequest("storage/" + userId, Method.DELETE);
            var result = await _restClient.ExecuteTaskAsync(request);
            return LogOnError(result);
        }

        public async Task<HttpStatusCode> DeleteOne(string userId, string dataStoreId)
        {
            var request = new RestRequest("storage/" + userId + "/" + dataStoreId, Method.DELETE);
            var result = await _restClient.ExecuteTaskAsync(request);
            return LogOnError(result);
        }

        public async Task<HttpStatusCode> DeleteAllElements(string userId, string dataStoreId)
        {
            var request = new RestRequest("storage/" + userId + "/" + dataStoreId + "/data", Method.DELETE);
            var result = await _restClient.ExecuteTaskAsync(request);
            return LogOnError(result);
        }

        public async Task<HttpStatusCode> DeleteOneElement(string userId, string dataStoreId, string elementId)
        {
            var request = new RestRequest("storage/" + userId + "/" + dataStoreId + "/data" + elementId, Method.DELETE);
            var result = await _restClient.ExecuteTaskAsync(request);
            return LogOnError(result);
        }

        private HttpStatusCode LogOnError(IRestResponse result)
        {
            if (result.StatusCode != HttpStatusCode.OK)
                _logger.Log(result.ErrorMessage, LogLevel.Critical);
            return result.StatusCode;
        }

        private string LogOnErrorReturnContent(IRestResponse result)
        {
            if (result.StatusCode != HttpStatusCode.OK)
                _logger.Log(result.ErrorMessage, LogLevel.Critical);
            return result.Content;
        }
    }
}