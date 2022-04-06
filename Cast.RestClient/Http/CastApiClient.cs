using Cast.RestClient.Extensions;
using Cast.RestClient.Http.Abstractions;
using System.Net.Http.Json;

namespace Cast.RestClient.Http
{
    internal class CastApiClient : ICastApiClient
    {
        private readonly HttpClient _httpClient;

        public CastApiClient(HttpClient client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            _httpClient = client;
        }

        public HttpClient HttpClient => _httpClient;

        public async Task<CastResponse<T>> DeleteAsync<T>(string apiPath, object? body, CancellationToken cancel = default)
        {
            var httpMessage = new HttpRequestMessage(HttpMethod.Delete, apiPath);
            httpMessage.SetJsonRequestHeaders();
            if (body != null) httpMessage.Content = JsonContent.Create(body);
            return await SendHttpRequest<T>(httpMessage);
        }

        public async Task<CastResponse<T>> GetAsync<T>(string apiPath, CancellationToken cancel = default)
        {
            var httpMessage = new HttpRequestMessage(HttpMethod.Get, apiPath);
            httpMessage.SetJsonRequestHeaders();
            return await SendHttpRequest<T>(httpMessage);
        }

        public async Task<CastResponse<T>> PostAsync<T>(string apiPath, object? body, CancellationToken cancel = default)
        {
            var httpMessage = new HttpRequestMessage(HttpMethod.Post, apiPath);
            httpMessage.SetJsonRequestHeaders();
            if (body != null) httpMessage.Content = JsonContent.Create(body);
            return await SendHttpRequest<T>(httpMessage);
        }

        public async Task<CastResponse<T>> PutAsync<T>(string apiPath, object? body, CancellationToken cancel = default)
        {
            var httpMessage = new HttpRequestMessage(HttpMethod.Put, apiPath);
            httpMessage.SetJsonRequestHeaders();
            if (body != null) httpMessage.Content = JsonContent.Create(body);
            return await SendHttpRequest<T>(httpMessage);
        }

        public async Task<CastResponse<T>> SendHttpRequest<T>(HttpRequestMessage request, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.SendAsync(request, cancellationToken);
                return new CastResponse<T>(response, new CustomJsonSerializer());
            }
            catch (Exception ex)
            {
                return new CastResponse<T>(ex);
            }
        }
    }
}