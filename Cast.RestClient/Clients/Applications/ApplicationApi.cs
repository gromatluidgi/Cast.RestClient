using Cast.RestClient.Clients.Applications.Queries;
using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Models;
using Cast.RestClient.Models.ValueObjects;

namespace Cast.RestClient.Clients.Applications
{
    public class ApplicationApi : IApplicationApi
    {
        private const string requestByDomainRoute = "domains/{0}/applications";
        private const string geByClientRefRoute = "domains/{0}/applications/clientref/{1}";
        private const string getCloudRoute = "domains/{0}/applications/cloud/{1}";
        private const string getClouAggregatedRoute = "domains/{0}/applications/cloud/{1}/aggreg";
        private const string getAggregateCvesRoute = "domains/{0}/applications/vulnerabilities/aggregated";
        private const string requestByIdRoute = "domains/{0}/applications/{1}";
        private const string getAlertsRoute = "domains/{0}/applications/{1}/alerts";
        private const string submitCampaignRoute = "domains/{0}/applications/{1}/campaigns/{2}/submit";
        private const string answerSurvayCampaignRoute = "domains/{0}/applications/{1}/campaigns/{2}/surveys/{3}";
        private const string getFilesMappingRoute = "domains/{0}/applications/{1}/components/mapping";
        private const string getProjectFilesMappingRoute = "domains/{0}/applications/{1}/components/{2}/mapping";
        private const string getCloudContainerRoute = "domains/{0}/applications/{1}/containerization";
        private const string getKeyworkRoute = "domains/{0}/applications/{1}/keyword";
        private const string getRecommendationRoute = "domains/{0}/applications/{1}/recommendation";
        private const string getResultsRoute = "domains/{0}/applications/{1}/results";
        private const string requestByResultIdRoute = "domains/{0}/applications/{1}/results/{2}";
        private const string submitResultByIdRoute = "domains/{0}/applications/{1}/results/{2}/submit";
        private const string postSurveyForResultRoute = "domains/{0}/applications/{1}/results/{2}/surveys/{3}";
        private const string getTagsRoute = "domains/{0}/applications/{1}/tags";
        private const string requestByTagIdRoute = "domains/{0}/applications/{1}/tags/{2}";
        private const string getAggregateTechnicalDebtRoute = "domains/{0}/applications/{1}/tags/{2}";
        private const string getThirdPartyRoute = "domains/{0}/applications/{1}/thirdparty";
        private const string getTransferabilityRoute = "domains/{0}/applications/{1}/transferability";
        private const string requestCvesExcludeRoute = "domains/{0}/applications/{1}/vulnerabilities/exclude";
        private const string updateCvesRoute = "domains/{0}/applications/{1}/vulnerabilities/reanalyze";
        private const string updateCveViewRoute = "domains/{0}/applications/{1}/vulnerabilities/view";

        public ApplicationApi(ICastApiClient client)
        {
            ApiClient = client;
        }

        public ICastApiClient ApiClient { get; }

        public async Task<ICastResponse<StatusResult<IEnumerable<Application>, IEnumerable<CastErrorModel<Application>>>>> CreateOrUpdateApplications(long domainId, IEnumerable<Application> applications)
        {
            var uriPath = string.Format(requestByDomainRoute, domainId);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            var response = await ApiClient.ExecuteCastRequestAsync<StatusResult<IEnumerable<Application>, IEnumerable<CastErrorModel<Application>>>>(request);

            return response;
        }

        public async Task<ICastResponse> DeleteApplicationByIdAsync(long domainId, long applicationId)
        {
            var uriPath = string.Format(requestByIdRoute, domainId, applicationId);
            var request = new CastRequest(HttpMethod.Delete, uriPath);

            var response = await ApiClient.ExecuteCastRequestAsync(request);

            return response;
        }

        public async Task<ICastResponse> GetAggregateCloudItemsByApplicationIdAsync(long domainId, long applicationId)
        {
            var uriPath = string.Format(getClouAggregatedRoute, domainId, applicationId);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            var response = await ApiClient.ExecuteCastRequestAsync(request);

            return response;
        }

        public async Task<ICastResponse<TopRiskAggregate>> GetAlertsByApplicationIdAsync(long domainId, long applicationId)
        {
            var uriPath = string.Format(getAlertsRoute, domainId, applicationId);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            var response = await ApiClient.ExecuteCastRequestAsync<TopRiskAggregate>(request);

            return response;
        }

        public async Task<ICastResponse<IEnumerable<Application>>> GetAllApplicationsByDomainIdAsync(long domainId)
        {
            var uriPath = string.Format(requestByDomainRoute, domainId);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            var response = await ApiClient.ExecuteCastRequestAsync<IEnumerable<Application>>(request);

            return response;
        }

        public async Task<ICastResponse<Application>> GetApplicationByClientRefAsync(long domainId, string clientRef)
        {
            var uriPath = string.Format(geByClientRefRoute, domainId, clientRef);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            var response = await ApiClient.ExecuteCastRequestAsync<Application>(request);

            return response;
        }

        public async Task<ICastResponse<Application>> GetApplicationByIdAsync(long domainId, long applicationId, ApplicationQuery? parameters = default)
        {
            var uriPath = string.Format(requestByIdRoute, domainId, applicationId);
            var request = new CastRequest(HttpMethod.Get, uriPath, parameters);

            var response = await ApiClient.ExecuteCastRequestAsync<Application>(request);

            return response;
        }

        /**
         * This api call return no content and has no specification.
         * Integration test should trigger error if any change occurs.
         */

        public async Task<ICastResponse> GetCloudItemsByApplicationIdAsync(long domainId, long applicationId)
        {
            var uriPath = string.Format(getCloudRoute, domainId, applicationId);
            var request = new CastRequest(HttpMethod.Get, uriPath);

            var response = await ApiClient.ExecuteCastRequestAsync(request);

            return response;
        }

        public async Task<ICastResponse<Application>> UpdateApplicationByIdAsync(long domainId, string applicationId, Application application)
        {
            var uriPath = string.Format(requestByIdRoute, domainId, applicationId);
            var request = new CastRequest(HttpMethod.Post, uriPath, application);

            var response = await ApiClient.ExecuteCastRequestAsync<Application>(request);
            return response;
        }
    }
}