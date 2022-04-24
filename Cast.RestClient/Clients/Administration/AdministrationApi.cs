using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Models;

namespace Cast.RestClient.Clients.Administration
{
    internal class AdministrationApi : IAdministrationApi
    {
        private const string CompanyDetailsEnpoint = "companies/{0}";
        private readonly ICastApiClient _client;

        public AdministrationApi(ICastApiClient client)
        {
            _client = client;
        }

        public async Task<ICastResponse<Company>> GetCompanyByIdAsync(int companyId)
        {
            var uriPath = string.Format(CompanyDetailsEnpoint, companyId);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            return await _client.ExecuteCastRequestAsync<Company>(request);
        }
    }
}