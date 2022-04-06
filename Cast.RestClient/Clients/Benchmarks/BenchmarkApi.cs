using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Models;
using Cast.RestClient.Models.Aggregates;

namespace Cast.RestClient.Clients.Benchmarks
{
    public class BenchmarkApi : IBenchmarkApi
    {
        private const string benchmarkAlertsRoute = "benchmark/alerts";
        private const string benchmarkMetricsRoute = "benchmark";
        private readonly ICastApiClient _client;

        public BenchmarkApi(ICastApiClient client)
        {
            _client = client;
        }

        public async Task<CastResponse<BenchmarkAlertsAggregate>> GetAllBenchmarkAlertsAsync()
        {
            var response = await _client.GetAsync<BenchmarkAlertsAggregate>(benchmarkAlertsRoute);
            return response;
        }

        public async Task<CastResponse<BenchmarkAlertsAggregate>> GetBenchmarkAlertsByTechnologiesAsync()
        {
            var response = await _client.PostAsync<BenchmarkAlertsAggregate>(benchmarkMetricsRoute, null);
            return response;
        }

        public async Task<CastResponse<Benchmark>> GetComputedBenchmarkMetricsAsync()
        {
            var response = await _client.GetAsync<Benchmark>(benchmarkMetricsRoute);
            return response;
        }
    }
}