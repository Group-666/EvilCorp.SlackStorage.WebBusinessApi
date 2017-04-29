﻿using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts
{
    public interface IClientDataManager
    {
        Task<string> Create(string userId, JObject dataStoreName);

        Task<string> Post(string userId, string dataStoreId, JObject data);

        Task<string> GetAll(string id);

        Task<string> GetOne(string userId, string dataStoreId);

        Task<string> GetElementAll(string userId, string dataStoreId);

        Task<string> GetElementOne(string userId, string dataStoreId, string elementId);

        Task<HttpStatusCode> DeleteAll(string userId);

        Task<HttpStatusCode> DeleteOne(string userId, string dataStoreId);

        Task<HttpStatusCode> DeleteElementAll(string userId, string dataStoreId);

        Task<HttpStatusCode> DeleteElementOne(string userId, string dataStoreId, string elementId);
    }
}