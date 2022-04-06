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

        public async Task<CastResponse<Company>> GetCompanyByIdAsync(int companyId)
        {
            var apiPath = string.Format(companyDetailsEnpoint, companyId);

            var response = await _client.GetAsync<Company>(apiPath);
            if (response == null) throw new InvalidOperationException();

            return response;
        }
    }
}