using Cast.RestClient.Http.Queries;

namespace Cast.RestClient.Clients.Clouds.Queries
{
    public class CloudQuery : QueryParameters
    {
        public CloudQuery()
        {
            Technologies = new();
        }

        public HashSet<string> Technologies { get; }
    }
}
