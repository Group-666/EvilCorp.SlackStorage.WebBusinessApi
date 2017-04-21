using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using RestSharp;
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
        private RestClient _restClient;

        public ClientDataRespository()
        {
            _restClient = new RestClient(REPOSITORYURL);
        }

        public async Task<string> GetAll(string userId)
        {
            var request = new RestRequest("storage/"+userId, Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);
            return result.Content;
        }

        public async Task<string> GetOne(string userId, string dataStoreId)
        {
            var request = new RestRequest("storage/"+userId+"/"+dataStoreId, Method.GET);

            var result = await _restClient.ExecuteTaskAsync(request);
            return result.Content;
        }

        public async Task<string> GetOneElement(string userId, string dataStoreId, string elementId)
        {
            var request = new RestRequest("storage/" + userId + "/" + dataStoreId + "/data/" + elementId, Method.GET);

            var result = await _restClient.ExecuteTaskAsync(request);
            return result.Content;
        }

        public async Task<string> GetAllElements(string userId, string dataStoreId)
        {
            var request = new RestRequest("storage/" + userId + "/" + dataStoreId + "/data", Method.GET);

            var result = await _restClient.ExecuteTaskAsync(request);
            return result.Content;
        }

        public async Task<string> Create(string userId, string dataStoreName)
        {
            var request = new RestRequest("storage/" + userId, Method.POST);
            request.AddParameter("Application/Json", dataStoreName, ParameterType.RequestBody);
            var result = await _restClient.ExecuteTaskAsync(request);
            return result.Content;
        }
        public async Task<string> Post(string userId, string dataStoreId, string data)
        {
            var request = new RestRequest("storage/" + userId + "/" + dataStoreId, Method.POST);
            request.AddParameter("Application/Json", data, ParameterType.RequestBody);
            var result = await _restClient.ExecuteTaskAsync(request);
            return result.Content;
        }
        //-----
        public async Task<string> DeleteAll(string userId)
        {
            var request = new RestRequest("storage/" + userId + "/" , Method.POST);
            request.AddParameter("Application/Json", userId, ParameterType.RequestBody);
            var result = await _restClient.ExecuteTaskAsync(request);
            return result.Content;
        }
        public async Task<string> DeleteOne(string userId, string dataStoreId)
        {
            var request = new RestRequest("storage/" + userId + "/" + dataStoreId, Method.POST);
            request.AddParameter("Application/Json", userId, ParameterType.RequestBody);
            var result = await _restClient.ExecuteTaskAsync(request);
            return result.Content;
        }
        public async Task<string> DeleteAllElements(string userId, string dataStoreId)
        {
            var request = new RestRequest("storage/" + userId + "/" + dataStoreId, Method.POST);
            request.AddParameter("Application/Json", userId, ParameterType.RequestBody);
            var result = await _restClient.ExecuteTaskAsync(request);
            return result.Content;
        }

        public async Task<string> DeleteOneElement(string userId, string dataStoreId, string elementId)
        {
            var request = new RestRequest("storage/" + userId + "/" + dataStoreId, Method.POST);
            request.AddParameter("Application/Json", userId, ParameterType.RequestBody);
            var result = await _restClient.ExecuteTaskAsync(request);
            return result.Content;
        }
    }
}