using Cast.RestClient.Http;
using Cast.RestClient.Models;
using Cast.RestClient.Models.Aggregates;
using Cast.RestClient.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast.RestClient.Clients.Benchmarks
{
    public interface IBenchmarkApi
    {
        Task<CastResponse<Benchmark>> GetComputedBenchmarkMetricsAsync();

        Task<CastResponse<BenchmarkAlertsAggregate>> GetAllBenchmarkAlertsAsync();

        Task<CastResponse<BenchmarkAlertsAggregate>> GetBenchmarkAlertsByTechnologiesAsync();
    }
}
