using Cast.RestClient.Authentication;
using Cast.RestClient.Clients.Administration;
using Cast.RestClient.Clients.Applications;
using Cast.RestClient.Clients.Benchmarks;
using Cast.RestClient.Clients.Domains;
using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Options;
using System.Net.Http.Headers;

namespace Cast.RestClient
{
    public class CastRestClient : Disposable, ICastRestClient
    {
        public CastRestClient(
            ICastAuthenticationProvider authenticationProvider,
            CastRestClientOptions options)
            : this(options)
        {
            SetAuthorizationHeader(authenticationProvider.GetAuthorizationHeader());
        }

        internal CastRestClient(CastRestClientOptions options)
        {
            HttpClient = new HttpClient();

            CastApiClient = new CastApiClient(options.HighlightApiUrl, HttpClient);
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

        internal HttpClient HttpClient { get; }

        internal HttpRequestHeaders HttpRequestHeaders => HttpClient.DefaultRequestHeaders;

        public void SetAuthorizationHeader(string authorization)
        {
            HttpRequestHeaders.Remove("Authorization");
            HttpRequestHeaders.Add("Authorization", authorization);
        }

        protected override void DisposeManagedObjects()
        {
            base.DisposeManagedObjects();
            HttpClient.Dispose();
        }
    }
}