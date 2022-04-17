using Cast.RestClient.Http.Abstractions;

namespace Cast.RestClient.Clients.Clouds
{
    public class CloudApi : ICloudApi
    {
        private const string GetContainerization = "cloud/containerization/{0}";
        private const string GetData = "cloud/data/{0}";
        private const string GetRequirements = "cloud/requirements/{0}";
        private const string GetTransferability = "cloud/transferability/{0}";

        public CloudApi(ICastApiClient client)
        {
            ApiClient = client;
        }

        public ICastApiClient ApiClient { get; }
    }
}
