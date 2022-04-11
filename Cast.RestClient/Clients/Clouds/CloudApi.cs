using Cast.RestClient.Http.Abstractions;

namespace Cast.RestClient.Clients.Clouds
{
    public class CloudApi : ICloudApi
    {
        private const string getContainerization = "cloud/containerization/{0}";
        private const string getData = "cloud/data/{0}";
        private const string getRequirements = "cloud/requirements/{0}";
        private const string getTransferability = "cloud/transferability/{0}";

        public CloudApi(ICastApiClient client)
        {
            ApiClient = client;
        }

        public ICastApiClient ApiClient { get; }
    }
}
