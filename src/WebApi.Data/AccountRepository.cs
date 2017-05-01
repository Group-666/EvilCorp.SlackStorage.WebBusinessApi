using RestSharp;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApi.Domain.Contracts;
using WebApi.Domain.Entities;

namespace WebApi.Data
{
    public class AccountRepository : IAccountRepository
    {
#if DEBUG
        private const string Repositoryurl = "http://localhost:53879/UserService.svc/";
#else
//Real URL
        private const string Repositoryurl = "http://localhost:53879/UserService.svc/";
#endif
        private readonly ILogger _logger;
        private readonly RestClient _restClient;

        public AccountRepository(ILogger logger)
        {
            _restClient = new RestClient(Repositoryurl);
            _logger = logger;
        }

        public async Task<string> Create(XDocument xml)
        {
            var request = new RestRequest("registeruser", Method.POST) { RequestFormat = DataFormat.Xml };
            request.AddParameter("text/xml", xml, ParameterType.RequestBody);

            var result = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(result);
        }

        public async Task<string> Login(string userId, string passwordHash)
        {
            var requestss = new RestRequest("login/" + userId + "/" + passwordHash, Method.GET) { RequestFormat = DataFormat.Xml };
            var response = await _restClient.ExecuteTaskAsync(requestss);

            return LogOnErrorReturnContent(response);
        }

        public async Task<string> GetAll()
        {
            var request = new RestRequest("getalluser", Method.GET) { RequestFormat = DataFormat.Xml };
            var response = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(response);
        }

        public async Task<string> GetOne(string userId)
        {
            var request = new RestRequest(userId, Method.GET) { RequestFormat = DataFormat.Xml };
            var response = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(response);
        }

        public async Task<string> Disable(string userId)
        {
            var request = new RestRequest("disableuser/" + userId, Method.GET) { RequestFormat = DataFormat.Xml };
            var response = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(response);
        }

        public async Task<string> Enable(string userId)
        {
            var request = new RestRequest("enableuser/" + userId, Method.GET) { RequestFormat = DataFormat.Xml };
            var response = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(response);
        }

        public async Task<string> Delete(string userId)
        {
            var request = new RestRequest("deleteuser/" + userId, Method.GET) { RequestFormat = DataFormat.Xml };
            var response = await _restClient.ExecuteTaskAsync(request);

            return LogOnErrorReturnContent(response);
        }

        private string LogOnErrorReturnContent(IRestResponse result)
        {
            if (result.StatusCode != HttpStatusCode.OK)
                _logger.Log(string.IsNullOrEmpty(result.ErrorMessage) ? result.ToString() : result.ErrorMessage, LogLevel.Critical);
            return result.Content;
        }
    }
}