using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Models;
using Cast.RestClient.Models.Enumerations;

namespace Cast.RestClient.Clients.Domains
{
    public class DomainApi : IDomainApi
    {
        private const string IndustrySegmentListRoute = "domains/industrySegment";
        private const string DomainByIdRoute = "domains/{0}";
        private readonly ICastApiClient _client;

        public DomainApi(ICastApiClient client)
        {
            _client = client;
        }

        public async Task<ICastResponse<Domain>> GetDomainByIdAsync(long id)
        {
            var uriPath = string.Format(DomainByIdRoute, id);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            return await _client.ExecuteCastRequestAsync<Domain>(request);
        }

        public async Task<ICastResponse<ICollection<IndustrySegment>>> GetIndustrySegmentsAsync()
        {
            var request = new CastRequest(HttpMethod.Get, IndustrySegmentListRoute);

            return await _client.ExecuteCastRequestAsync<ICollection<IndustrySegment>>(request);
        }
    }
}