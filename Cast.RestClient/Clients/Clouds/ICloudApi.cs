using Cast.RestClient.Http.Abstractions;

namespace Cast.RestClient.Clients.Clouds
{
    public interface ICloudApi
    {
        ICastApiClient ApiClient { get; }
    }
}
