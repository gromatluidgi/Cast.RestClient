﻿using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Models;
using Cast.RestClient.Models.Aggregates;

namespace Cast.RestClient.Clients.Benchmarks
{
    public class BenchmarkApi : IBenchmarkApi
    {
        private const string BenchmarkAlertsRoute = "benchmark/alerts";
        private const string BenchmarkMetricsRoute = "benchmark";
        private readonly ICastApiClient _client;

        public BenchmarkApi(ICastApiClient client)
        {
            _client = client;
        }

        public async Task<ICastResponse<BenchmarkAlertsAggregate>> GetAllBenchmarkAlertsAsync()
        {
            var request = new CastRequest(HttpMethod.Get, BenchmarkAlertsRoute);

            var response = await _client.ExecuteCastRequestAsync<BenchmarkAlertsAggregate>(request);

            return response;
        }

        public async Task<ICastResponse<BenchmarkAlertsAggregate>> GetBenchmarkAlertsByTechnologiesAsync()
        {
            var request = new CastRequest(HttpMethod.Post, BenchmarkMetricsRoute);

            var response = await _client.ExecuteCastRequestAsync<BenchmarkAlertsAggregate>(request);

            return response;
        }

        public async Task<ICastResponse<Benchmark>> GetComputedBenchmarkMetricsAsync()
        {
            var request = new CastRequest(HttpMethod.Get, BenchmarkMetricsRoute);

            var response = await _client.ExecuteCastRequestAsync<Benchmark>(request);

            return response;
        }
    }
}