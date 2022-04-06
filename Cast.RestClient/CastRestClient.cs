using Cast.RestClient.Authentication;
using Cast.RestClient.Clients.Administration;
using Cast.RestClient.Clients.Benchmarks;
using Cast.RestClient.Clients.Domains;
using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Options;

namespace Cast.RestClient
{
    public class CastRestClient : Disposable, ICastRestClient
    {

        private readonly HttpClient _httpClient;

        public CastRestClient(
            ICastAuthenticationProvider authenticationProvider, 
            CastRestClientOptions options)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(options.HighlightApiUrl, UriKind.Absolute)
            };

            SetAuthorizationHeader(authenticationProvider.GetAuthorizationHeader());

            CastApiClient = new CastApiClient(_httpClient);
            Administration = new AdministrationApi(CastApiClient);
            Benchmark = new BenchmarkApi(CastApiClient);
            Domain = new DomainApi(CastApiClient);
        }

        public ICastApiClient CastApiClient { get; }

        public IAdministrationApi Administration { get; }

        public IBenchmarkApi Benchmark { get; }

        public IDomainApi Domain { get; }

        public void SetAuthorizationHeader(string authorization)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", authorization);
        }

        protected override void DisposeManagedObjects()
        {
            base.DisposeManagedObjects();
            _httpClient.Dispose();
        }
    }
}