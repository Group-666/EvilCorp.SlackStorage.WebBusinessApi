using EvilCorp.SlackStorage.WebApi.Domain.Contracts;
using RestSharp;
using System.Threading.Tasks;

namespace EvilCorp.SlackStorage.WebApi.Data
{
    public class AccountRepository : IAccountRepository
    {
#if DEBUG
        private const string Repositoryurl = "http://localhost:53879/UserService.svc/";
#else
//Real URL
        private const string REPOSITORYURL = "http://localhost/api/storage";
#endif
        private readonly ILogger _logger;
        private readonly RestClient _restClient;

        public AccountRepository(ILogger logger)
        {
            _restClient = new RestClient(Repositoryurl);
            _logger = logger;
        }

        public async Task<string> GetAll(string userId)
        {
            var request = new RestRequest(userId, Method.GET);
            var result = await _restClient.ExecuteTaskAsync(request);

            return result.Content;
        }

        public async Task<string> Login(string userId, string passwordHash)
        {
            //var request = new RestRequest(userId + "/" + passwordHash, Method.GET);
            //var result = await _restClient.ExecuteTaskAsync(request);

            var requestss = new RestRequest("login/" + userId + "/" + passwordHash, Method.GET)
            {
                RequestFormat = DataFormat.Xml
            };
            var response = await _restClient.ExecuteTaskAsync(requestss);

            var login = new login();
            login.userId = response.Content;

            return response.Content;
        }

        private class login
        {
            public string username;
            public string password;
            public string userId;
        }
    }
}