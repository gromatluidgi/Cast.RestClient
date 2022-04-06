using Cast.RestClient.Authentication;
using Cast.RestClient.Http;
using Cast.RestClient.Options;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast.RestClient.Tests
{
    public static class TestHelpers
    {
        public static ICastRestClient CreateClient(CastRestClientOptions options)
        {
            ICastRestClient client;
            client = new CastRestClient(new CastBearerAuthenticationProvider("Test"), options);
            return client;
        }

        public static ICastRestClient CreateResponseClient(string response, CastRestClientOptions options)
        {
            var client = (CastRestClient)CreateClient(options);
            return client;
        }

    }
}
