using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using WebApi.Domain.Contracts;
using WebApi.Domain.Entities;

namespace WebApi.Data
{
    public class ClientDataRepository : IClientDataRepository
    {
#if DEBUG
        private const string Repositoryurl = "http://localhost:5000/api/storage/";
#else
        //Real URL
        private const string REPOSITORYURL = "http://localhost:5000/api/storage";
#endif
        private readonly ILogger _logger;
        private readonly RestClient _restClient;

        public ClientDataRepository(ILogger logger)
        {
            _restClient = new RestClient(Repositoryurl);
            _logger = logger;
        }

        public async Task<string> Create(string userId, JObject dataStoreName)
        {
            var request = new RestRequest(userId, Method.POST);
            request.AddParameter("Application/Json", dataStoreName, ParameterType.RequestBody);

            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result, _logger.GetCurrentMethodName());
        }

        public async Task<string> Post(string userId, string dataStoreId, JObject data)
        {
            var request = new RestRequest(userId + "/" + dataStoreId, Method.POST);
            request.AddParameter("Application/Json", data, ParameterType.RequestBody);

            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result, _logger.GetCurrentMethodName());
        }

        public async Task<string> GetAll(string userId)
        {
            var request = new RestRequest(userId, Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result, _logger.GetCurrentMethodName());
        }

        public async Task<string> Get(string userId, string dataStoreId)
        {
            var request = new RestRequest(userId + "/" + dataStoreId, Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result, _logger.GetCurrentMethodName());
        }

        public async Task<string> GetAllElement(string userId, string dataStoreId)
        {
            var request = new RestRequest(userId + "/" + dataStoreId + "/data/", Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result, _logger.GetCurrentMethodName());
        }

        public async Task<string> GetElement(string userId, string dataStoreId, string elementId)
        {
            var request = new RestRequest(userId + "/" + dataStoreId + "/data/" + elementId, Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result, _logger.GetCurrentMethodName());
        }

        public async Task<string> UpdateElement(string userId, string dataStoreId, string elementId, JObject body)
        {
            var request = new RestRequest(userId + "/" + dataStoreId + "/data/" + elementId, Method.PUT);
            request.AddParameter("Application/Json", body, ParameterType.RequestBody);

            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result, _logger.GetCurrentMethodName());
        }

        public async Task<string> DeleteAll(string userId)
        {
            var request = new RestRequest(userId, Method.DELETE);
            var result = await _restClient.ExecuteTaskAsync(request);
            return LogOnErrorReturnContent(result, _logger.GetCurrentMethodName());
        }

        public async Task<string> Delete(string userId, string dataStoreId)
        {
            var request = new RestRequest(userId + "/" + dataStoreId, Method.DELETE);
            var result = await _restClient.ExecuteTaskAsync(request);
            return LogOnErrorReturnContent(result, _logger.GetCurrentMethodName());
        }

        public async Task<string> DeleteAllElement(string userId, string dataStoreId)
        {
            var request = new RestRequest(userId + "/" + dataStoreId + "/data/", Method.DELETE);
            var result = await _restClient.ExecuteTaskAsync(request);
            return LogOnErrorReturnContent(result, _logger.GetCurrentMethodName());
        }

        public async Task<string> DeleteElement(string userId, string dataStoreId, string elementId)
        {
            var request = new RestRequest(userId + "/" + dataStoreId + "/data/" + elementId, Method.DELETE);
            var result = await _restClient.ExecuteTaskAsync(request);
            return LogOnErrorReturnContent(result, _logger.GetCurrentMethodName());
        }

        private string LogOnErrorReturnContent(IRestResponse result, string methodName)
        {
            var errorMessage = JsonConvert.SerializeObject(new
            {
                methodName,
                content = result.Content,
                exceptionMessage = result.ErrorException,
                errorMessage = result.ErrorMessage,
                statusCode = (int)result.StatusCode
            });
            if (result.StatusCode != HttpStatusCode.OK)
            {
                _logger.Log(errorMessage, result.StatusCode != HttpStatusCode.InternalServerError ? LogLevel.Error : LogLevel.Warning);
                throw new HttpException((int)result.StatusCode, errorMessage);
            }
            _logger.Log(errorMessage, LogLevel.Trace);
            return result.Content;
        }
    }
}