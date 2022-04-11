using Cast.RestClient.Clients.Applications.Queries;
using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Models;
using Cast.RestClient.Models.ValueObjects;

namespace Cast.RestClient.Clients.Applications
{
    public interface IApplicationApi
    {
        ICastApiClient ApiClient { get; }

        Task<ICastResponse<IEnumerable<Application>>> GetAllApplicationsByDomainIdAsync(long domainId);

        Task<ICastResponse<StatusResult<IEnumerable<Application>, IEnumerable<CastErrorModel<Application>>>>> CreateOrUpdateApplications(long domainId, IEnumerable<Application> applications);

        Task<ICastResponse<Application>> GetApplicationByClientRefAsync(long domainId, string clientRef);

        Task<ICastResponse> GetCloudItemsByApplicationIdAsync(long domainId, long applicationId);

        Task<ICastResponse> GetAggregateCloudItemsByApplicationIdAsync(long domainId, long applicationId);

        Task<ICastResponse<Application>> GetApplicationByIdAsync(long domainId, long applicationId, ApplicationQuery? parameters = default);

        Task<ICastResponse<Application>> UpdateApplicationByIdAsync(long domainId, string applicationId, Application application);

        Task<ICastResponse> DeleteApplicationByIdAsync(long domainId, long applicationId);

        Task<ICastResponse<TopRiskAggregate>> GetAlertsByApplicationIdAsync(long domainId, long applicationId);
    }
}