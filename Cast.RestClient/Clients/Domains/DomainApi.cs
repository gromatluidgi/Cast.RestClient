using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Models;
using Cast.RestClient.Models.Enums;

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

            var response = await _client.ExecuteCastRequestAsync<Domain>(request);
            return response;
        }

        public async Task<ICastResponse<IEnumerable<IndustrySegment>>> GetIndustrySegmentsAsync()
        {
            var request = new CastRequest(HttpMethod.Get, IndustrySegmentListRoute);

            var response = await _client.ExecuteCastRequestAsync<IEnumerable<IndustrySegment>>(request);

            return response;
        }
    }
}