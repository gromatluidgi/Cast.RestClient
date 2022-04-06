using Cast.RestClient.Clients.Administration;
using Cast.RestClient.Clients.Benchmarks;
using Cast.RestClient.Clients.Domains;
using Cast.RestClient.Http;

namespace Cast.RestClient
{
    public interface ICastRestClient
    {
        void SetAuthorizationHeader(string authorization);

        IAdministrationApi Administration { get; }

        IBenchmarkApi Benchmark { get; }

        IDomainApi Domain { get; }
    }
}