using Cast.RestClient.Authentication;

namespace Cast.RestClient.Http.Abstractions
{
    public interface ICastApiClient
    {
        HttpClient HttpClient { get; }

        Task<CastResponse<T>> SendHttpRequest<T>(HttpRequestMessage request, CancellationToken cancellationToken = default);

        Task<CastResponse<T>> GetAsync<T>(string apiPath, CancellationToken cancel = default);

        Task<CastResponse<T>> PostAsync<T>(string apiPath, object? body, CancellationToken cancel = default);

        Task<CastResponse<T>> PutAsync<T>(string apiPath, object? body, CancellationToken cancel = default);

        Task<CastResponse<T>> DeleteAsync<T>(string apiPath, object? body, CancellationToken cancel = default);
    }
}