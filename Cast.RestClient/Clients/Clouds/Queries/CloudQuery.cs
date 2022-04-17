using Cast.RestClient.Http;
using System.Collections.Generic;

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
