using Cast.RestClient.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast.RestClient.Clients.Clouds.Queries
{
    public class CloudQuery : QueryParameters
    {
        public CloudQuery() {
            Technologies = new();
        }

        public HashSet<string> Technologies { get; }

    }
}
