using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Models;
using Cast.RestClient.Models.Aggregates;

namespace Cast.RestClient.Clients.Benchmarks
{
    public interface IBenchmarkApi
    {
        Task<ICastResponse<Benchmark>> GetComputedBenchmarkMetricsAsync();

        Task<ICastResponse<BenchmarkAlertsAggregate>> GetAllBenchmarkAlertsAsync();

        Task<ICastResponse<BenchmarkAlertsAggregate>> GetBenchmarkAlertsByTechnologiesAsync();
    }
}