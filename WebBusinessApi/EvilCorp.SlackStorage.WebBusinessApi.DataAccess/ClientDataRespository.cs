﻿using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using EvilCorp.SlackStorage.WebBusinessApi.Domain.Entities;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EvilCorp.SlackStorage.WebBusinessApi.Data
{
    public class ClientDataRespository : IClientDataRespository
    {
#if DEBUG
        private static string REPOSITORYURL = "http://localhost:49752/api/storage/";
#else
        //Real URL
        private static string REPOSITORYURL = "http://localhost/api/storage";
#endif
        private readonly ILogger _logger;
        private readonly RestClient _restClient;

        public ClientDataRespository(ILogger logger)
        {
            _restClient = new RestClient(REPOSITORYURL);
            _logger = logger;
        }

        public async Task<string> GetAll(string userId)
        {
            var request = new RestRequest(userId, Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result);
        }

        public async Task<string> GetOne(string userId, string dataStoreId)
        {
            var request = new RestRequest(userId + "/" + dataStoreId, Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result);
        }

        public async Task<string> GetElementOne(string userId, string dataStoreId, string elementId)
        {
            var request = new RestRequest(userId + "/" + dataStoreId + "/data/" + elementId, Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result);
        }

        public async Task<string> GetElementAll(string userId, string dataStoreId)
        {
            var request = new RestRequest(userId + "/" + dataStoreId + "/data", Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result);
        }

        public async Task<string> Create(string userId, JObject dataStoreName)
        {
            var request = new RestRequest(userId, Method.POST);
            request.AddParameter("Application/Json", dataStoreName, ParameterType.RequestBody);

            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result);
        }

        public async Task<string> Post(string userId, string dataStoreId, JObject data)
        {
            var request = new RestRequest(userId + "/" + dataStoreId, Method.POST);
            request.AddParameter("Application/Json", data, ParameterType.RequestBody);

            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result);
        }

        public async Task<HttpStatusCode> DeleteAll(string userId)
        {
            var request = new RestRequest(userId, Method.DELETE);
            var result = await _restClient.ExecuteTaskAsync(request);
            return LogOnError(result);
        }

        public async Task<HttpStatusCode> DeleteOne(string userId, string dataStoreId)
        {
            var request = new RestRequest(userId + "/" + dataStoreId, Method.DELETE);
            var result = await _restClient.ExecuteTaskAsync(request);
            return LogOnError(result);
        }

        public async Task<HttpStatusCode> DeleteElementAll(string userId, string dataStoreId)
        {
            var request = new RestRequest(userId + "/" + dataStoreId + "/data", Method.DELETE);
            var result = await _restClient.ExecuteTaskAsync(request);
            return LogOnError(result);
        }

        public async Task<HttpStatusCode> DeleteElementOne(string userId, string dataStoreId, string elementId)
        {
            var request = new RestRequest(userId + "/" + dataStoreId + "/data" + elementId, Method.DELETE);
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