using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Models;

namespace Cast.RestClient.Clients.Administration
{
    internal class AdministrationApi : IAdministrationApi
    {
        private const string companyDetailsEnpoint = "companies/{0}";
        private const string auditLogEnpoint = "companies/{0}/audit";

        private readonly ICastApiClient _client;

        public AdministrationApi(ICastApiClient client)
        {
            _client = client;
        }

        public async Task<ICastResponse<Company>> GetCompanyByIdAsync(int companyId)
        {
            var uriPath = string.Format(companyDetailsEnpoint, companyId);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            var response = await _client.ExecuteCastRequestAsync<Company>(request);

            return response;
        }
    }
}