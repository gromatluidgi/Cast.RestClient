using Cast.RestClient.Http;
using Cast.RestClient.Models;

namespace Cast.RestClient.Clients.Administration
{
    public interface IAdministrationApi
    {
        Task<CastResponse<Company>> GetCompanyByIdAsync(int companyId);
    }
}