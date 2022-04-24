using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Models;
using Cast.RestClient.Models.Enumerations;

namespace Cast.RestClient.Clients.Domains
{
    public interface IDomainApi
    {
        Task<ICastResponse<ICollection<IndustrySegment>>> GetIndustrySegmentsAsync();

        Task<ICastResponse<Domain>> GetDomainByIdAsync(long id);
    }
}