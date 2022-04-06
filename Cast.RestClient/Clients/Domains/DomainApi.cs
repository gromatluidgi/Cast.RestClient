using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Models;
using Cast.RestClient.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast.RestClient.Clients.Domains
{
    public class DomainApi : IDomainApi
    {
        private const string industrySegmentListRoute = "domains/industrySegment";
        private const string domainByIdRoute = "domains/{0}";
        private readonly ICastApiClient _client;

        public DomainApi(ICastApiClient client)
        {
            _client = client;
        }

        public async Task<CastResponse<Domain>> GetDomainByIdAsync(long id)
        {
            var uriPath = string.Format(domainByIdRoute, id);
            var response = await _client.GetAsync<Domain>(uriPath);
            return response;
        }

        public async Task<CastResponse<IEnumerable<IndustrySegment>>> GetIndustrySegmentsAsync()
        {
            var response = await _client.GetAsync<IEnumerable<IndustrySegment>>(industrySegmentListRoute);
            return response;
        }
    }
}
