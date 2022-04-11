using Cast.RestClient.Authentication;
using Cast.RestClient.Clients.Administration;
using Cast.RestClient.Clients.Applications;
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
            _httpClient = new HttpClient();

            SetAuthorizationHeader(authenticationProvider.GetAuthorizationHeader());

            CastApiClient = new CastApiClient(options.HighlightApiUrl, _httpClient);
            Administration = new AdministrationApi(CastApiClient);
            Benchmark = new BenchmarkApi(CastApiClient);
            Domain = new DomainApi(CastApiClient);
            Application = new ApplicationApi(CastApiClient);
        }

        public IAdministrationApi Administration { get; }
        public IApplicationApi Application { get; }
        public IBenchmarkApi Benchmark { get; }
        public ICastApiClient CastApiClient { get; }
        public IDomainApi Domain { get; }

        public void SetAuthorizationHeader(string authorization)
        {
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            _httpClient.DefaultRequestHeaders.Add("Authorization", authorization);
        }

        protected override void DisposeManagedObjects()
        {
            base.DisposeManagedObjects();
            _httpClient.Dispose();
        }
    }
}