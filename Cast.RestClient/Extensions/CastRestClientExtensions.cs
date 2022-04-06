using Cast.RestClient.Authentication;
using Cast.RestClient.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Cast.RestClient.Extensions
{
    public static class CastRestClientExtensions
    {
        public static IServiceCollection AddCastRestClient(
            this IServiceCollection services,
            ICastAuthenticationProvider authenticationProvider,
            CastRestClientOptions options)
        {
            services.AddSingleton(authenticationProvider);
            services.AddSingleton(options);

            services.AddTransient<ICastRestClient, CastRestClient>();

            return services;
        }
    }
}