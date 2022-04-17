using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Models;

namespace Cast.RestClient.Clients.Administration
{
    public interface IAdministrationApi
    {
        Task<ICastResponse<Company>> GetCompanyByIdAsync(int companyId);
    }
}