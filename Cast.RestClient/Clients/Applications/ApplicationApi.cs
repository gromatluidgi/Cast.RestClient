using Cast.RestClient.Clients.Applications.Queries;
using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Models;
using Cast.RestClient.Models.ValueObjects;

namespace Cast.RestClient.Clients.Applications
{
    public class ApplicationApi : IApplicationApi
    {
        private const string RequestByDomainRoute = "domains/{0}/applications";
        private const string GeByClientRefRoute = "domains/{0}/applications/clientref/{1}";
        private const string GetCloudRoute = "domains/{0}/applications/cloud/{1}";
        private const string GetClouAggregatedRoute = "domains/{0}/applications/cloud/{1}/aggreg";
        private const string GetAggregateCvesRoute = "domains/{0}/applications/vulnerabilities/aggregated";
        private const string RequestByIdRoute = "domains/{0}/applications/{1}";
        private const string GetAlertsRoute = "domains/{0}/applications/{1}/alerts";
        private const string SubmitCampaignRoute = "domains/{0}/applications/{1}/campaigns/{2}/submit";
        private const string AnswerSurvayCampaignRoute = "domains/{0}/applications/{1}/campaigns/{2}/surveys/{3}";
        private const string GetFilesMappingRoute = "domains/{0}/applications/{1}/components/mapping";
        private const string GetProjectFilesMappingRoute = "domains/{0}/applications/{1}/components/{2}/mapping";
        private const string GetCloudContainerRoute = "domains/{0}/applications/{1}/containerization";
        private const string GetKeyworkRoute = "domains/{0}/applications/{1}/keyword";
        private const string GetRecommendationRoute = "domains/{0}/applications/{1}/recommendation";
        private const string GetResultsRoute = "domains/{0}/applications/{1}/results";
        private const string RequestByResultIdRoute = "domains/{0}/applications/{1}/results/{2}";
        private const string SubmitResultByIdRoute = "domains/{0}/applications/{1}/results/{2}/submit";
        private const string PostSurveyForResultRoute = "domains/{0}/applications/{1}/results/{2}/surveys/{3}";
        private const string GetTagsRoute = "domains/{0}/applications/{1}/tags";
        private const string RequestByTagIdRoute = "domains/{0}/applications/{1}/tags/{2}";
        private const string GetAggregateTechnicalDebtRoute = "domains/{0}/applications/{1}/tags/{2}";
        private const string GetThirdPartyRoute = "domains/{0}/applications/{1}/thirdparty";
        private const string GetTransferabilityRoute = "domains/{0}/applications/{1}/transferability";
        private const string RequestCvesExcludeRoute = "domains/{0}/applications/{1}/vulnerabilities/exclude";
        private const string UpdateCvesRoute = "domains/{0}/applications/{1}/vulnerabilities/reanalyze";
        private const string UpdateCveViewRoute = "domains/{0}/applications/{1}/vulnerabilities/view";

        public ApplicationApi(ICastApiClient client)
        {
            ApiClient = client;
        }

        public ICastApiClient ApiClient { get; }

        public async Task<ICastResponse<StatusResult<IEnumerable<Application>, IEnumerable<CastErrorModel<Application>>>>> CreateOrUpdateApplications(long domainId, IEnumerable<Application> applications)
        {
            var uriPath = string.Format(RequestByDomainRoute, domainId);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            var response = await ApiClient.ExecuteCastRequestAsync<StatusResult<IEnumerable<Application>, IEnumerable<CastErrorModel<Application>>>>(request);

            return response;
        }

        public async Task<ICastResponse> DeleteApplicationByIdAsync(long domainId, long applicationId)
        {
            var uriPath = string.Format(RequestByIdRoute, domainId, applicationId);
            var request = new CastRequest(HttpMethod.Delete, uriPath);

            var response = await ApiClient.ExecuteCastRequestAsync(request);

            return response;
        }

        public async Task<ICastResponse> GetAggregateCloudItemsByApplicationIdAsync(long domainId, long applicationId)
        {
            var uriPath = string.Format(GetClouAggregatedRoute, domainId, applicationId);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            var response = await ApiClient.ExecuteCastRequestAsync(request);

            return response;
        }

        public async Task<ICastResponse<TopRiskAggregate>> GetAlertsByApplicationIdAsync(long domainId, long applicationId)
        {
            var uriPath = string.Format(GetAlertsRoute, domainId, applicationId);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            var response = await ApiClient.ExecuteCastRequestAsync<TopRiskAggregate>(request);

            return response;
        }

        public async Task<ICastResponse<IEnumerable<Application>>> GetAllApplicationsByDomainIdAsync(long domainId)
        {
            var uriPath = string.Format(RequestByDomainRoute, domainId);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            var response = await ApiClient.ExecuteCastRequestAsync<IEnumerable<Application>>(request);

            return response;
        }

        public async Task<ICastResponse<Application>> GetApplicationByClientRefAsync(long domainId, string clientRef)
        {
            var uriPath = string.Format(GeByClientRefRoute, domainId, clientRef);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            var response = await ApiClient.ExecuteCastRequestAsync<Application>(request);

            return response;
        }

        public async Task<ICastResponse<Application>> GetApplicationByIdAsync(long domainId, long applicationId, ApplicationQuery? parameters = default)
        {
            var uriPath = string.Format(RequestByIdRoute, domainId, applicationId);
            var request = new CastRequest(HttpMethod.Get, uriPath, parameters);

            var response = await ApiClient.ExecuteCastRequestAsync<Application>(request);

            return response;
        }

        /// <summary>
        /// This api call return no content and has no specification.<br/>
        /// Integration test should trigger error if any change occurs.
        /// </summary>
        public async Task<ICastResponse> GetCloudItemsByApplicationIdAsync(long domainId, long applicationId)
        {
            var uriPath = string.Format(GetCloudRoute, domainId, applicationId);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            var response = await ApiClient.ExecuteCastRequestAsync(request);

            return response;
        }

        public async Task<ICastResponse<Application>> UpdateApplicationByIdAsync(long domainId, string applicationId, Application application)
        {
            var uriPath = string.Format(RequestByIdRoute, domainId, applicationId);
            var request = new CastRequest(HttpMethod.Post, uriPath, application);

            var response = await ApiClient.ExecuteCastRequestAsync<Application>(request);
            return response;
        }
    }
}