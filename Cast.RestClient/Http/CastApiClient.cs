using Cast.RestClient.Extensions;
using Cast.RestClient.Helpers;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Http.Serialization;
using System.Net.Http.Json;

namespace Cast.RestClient.Http
{
    internal class CastApiClient : ICastApiClient
    {
        private readonly string _baseUri;
        private readonly HttpClient _httpClient;
        private readonly ISerializer _serializer;

        public CastApiClient(string baseUri, HttpClient client)
        {
            Ensure.ArgumentNotNullOrEmptyString(baseUri, nameof(baseUri));
            Ensure.ArgumentNotNull(client, nameof(client));

            _baseUri = baseUri;
            _httpClient = client;
            _serializer = new CustomJsonSerializer();
        }

        public string BaseUri { get => _baseUri; }

        public HttpClient HttpClient => _httpClient;

        public async Task<ICastResponse<T>> ExecuteCastRequestAsync<T>(ICastRequest request, CancellationToken cancellationToken = default)
        {
            var httpMessage = new HttpRequestMessage(request.Method, request.BuildUri(BaseUri).RequestUri);

            if (request.Body != null)
            {
                httpMessage.Content = JsonContent.Create(request.Body);
            }

            httpMessage.SetJsonRequestHeaders();

            try
            {
                var response = await _httpClient.SendAsync(httpMessage, cancellationToken).ConfigureAwait(false);
                return new CastResponse<T>(response, _serializer)
                {
                    Request = request,
                };
            }
            catch (Exception ex)
            {
                return new CastResponse<T>(ex)
                {
                    Request = request,
                };
            }
        }

        public async Task<ICastResponse> ExecuteCastRequestAsync(ICastRequest request, CancellationToken cancellationToken = default)
        {
            return await ExecuteCastRequestAsync<object>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<ICastResponse<T>> SendHttpRequestAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
                return new CastResponse<T>(response, _serializer);
            }
            catch (Exception ex)
            {
                return new CastResponse<T>(ex);
            }
        }

        public async Task<ICastResponse> SendHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
        {
            return await SendHttpRequestAsync<object>(request, cancellationToken).ConfigureAwait(false);
        }
    }
}