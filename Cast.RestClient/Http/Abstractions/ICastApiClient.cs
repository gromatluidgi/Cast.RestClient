namespace Cast.RestClient.Http.Abstractions
{
    public interface ICastApiClient
    {
        HttpClient HttpClient { get; }

        string BaseUri { get; }

        Task<ICastResponse> SendHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken = default);

        Task<ICastResponse<T>> SendHttpRequestAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken = default);

        Task<ICastResponse<T>> ExecuteCastRequestAsync<T>(ICastRequest request, CancellationToken cancellationToken = default);

        Task<ICastResponse> ExecuteCastRequestAsync(ICastRequest request, CancellationToken cancellationToken = default);
    }
}