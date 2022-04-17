using Cast.RestClient.Authentication;
using Cast.RestClient.Options;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Cast.RestClient.Integration.Tests
{
    public abstract class IntegrationTest
    {
        protected const long DemoApplicationId = 28485;

        private readonly IConfiguration _configuration;

        protected CastRestClientOptions Options { get; private set; } = null!;

        protected IntegrationTest()
        {
            _configuration = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("config.json", true)
                         .AddEnvironmentVariables()
                         .Build();
        }

        protected virtual ICastRestClient GetAnonymousClient()
        {
            var authenticationProvider = new CastBasicAuthenticationProvider("anon", "anon");

            Options = new CastRestClientOptions(_configuration["CAST_API_URL"])
            {
                DomainId = Convert.ToInt64(_configuration["CAST_DOMAIN_ID"]),
            };

            return new CastRestClient(authenticationProvider, Options);
        }

        protected virtual ICastRestClient GetBasicAuthClient()
        {
            var authenticationProvider = new CastBasicAuthenticationProvider(_configuration["CAST_LOGIN"], _configuration["CAST_PASSWORD"]);
            Options = new CastRestClientOptions(_configuration["CAST_API_URL"])
            {
                DomainId = Convert.ToInt64(_configuration["CAST_DOMAIN_ID"]),
            };

            return new CastRestClient(authenticationProvider, Options);
        }

        protected virtual ICastRestClient GetTokenAuthClient()
        {
            var authenticationProvider = new CastBearerAuthenticationProvider(_configuration["CAST_ACCESS_TOKEN"]);
            Options = new CastRestClientOptions(_configuration["CAST_API_URL"])
            {
                DomainId = Convert.ToInt64(_configuration["CAST_DOMAIN_ID"]),
            };

            return new CastRestClient(authenticationProvider, Options);
        }
    }
}