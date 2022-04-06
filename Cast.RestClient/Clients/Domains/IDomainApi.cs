using Cast.RestClient.Http;
using Cast.RestClient.Models;
using Cast.RestClient.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast.RestClient.Clients.Domains
{
    public interface IDomainApi
    {
        Task<CastResponse<IEnumerable<IndustrySegment>>> GetIndustrySegmentsAsync();

        Task<CastResponse<Domain>> GetDomainByIdAsync(long id);
    }
}
