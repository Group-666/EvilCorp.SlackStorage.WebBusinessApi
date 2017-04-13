using EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebBusinessApi.WebHost.DataAccess.Storage
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

        public async Task<string> Test()
        {
            var request = new RestRequest("storage", Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);
            return result.Content;
        }
    }
}