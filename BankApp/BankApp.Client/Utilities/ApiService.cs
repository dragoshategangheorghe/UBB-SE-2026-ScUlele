using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BankApp.Client.Utilities
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private string? _token;
        private int? _currentUserId;
        public ApiService(string baseUrl = "http://localhost:5024")
        {
            // TODO: implement api service logic
            ;
        }

        public void SetToken(string token)
        {
            // TODO: implement set token logic
            ;
        }

        public void SetCurrentUserId(int userId)
        {
            // TODO: implement set current user id logic
            ;
        }

        public int? GetCurrentUserId()
        {
            // TODO: load current user id
            return default !;
        }

        public void ClearToken()
        {
            // TODO: implement clear token logic
            ;
        }

        public string? GetToken()
        {
            // TODO: load token
            return default !;
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            // TODO: implement post logic
            return default !;
        }

        public async Task<TResponse?> GetAsync<TResponse>(string endpoint)
        {
            // TODO: implement get logic
            return default !;
        }

        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            // TODO: implement put logic
            return default !;
        }

        public async Task<DownloadResponse?> PostDownloadAsync<TRequest>(string endpoint, TRequest data)
        {
            // TODO: implement export logic
            return default !;
        }

        public async Task<DownloadResponse?> GetDownloadAsync(string endpoint)
        {
            // TODO: load download
            return default !;
        }

        private static async Task<DownloadResponse> CreateDownloadResponseAsync(HttpResponseMessage response)
        {
            // TODO: implement export logic
            return default !;
        }
    }
}