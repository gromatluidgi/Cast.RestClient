using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Models;
using Cast.RestClient.Models.Enums;

namespace Cast.RestClient.Clients.Domains
{
    public interface IDomainApi
    {
        Task<ICastResponse<IEnumerable<IndustrySegment>>> GetIndustrySegmentsAsync();

        Task<ICastResponse<Domain>> GetDomainByIdAsync(long id);
    }
}