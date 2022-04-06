using System;
using System.Threading.Tasks;
using Xunit;

namespace Cast.RestClient.Integration.Tests.Endpoints.Benchmarks
{
    public class BenchmarkApiTest : IntegrationTest
    {
        [Fact]
        public async Task AnonymousClient_Should_Returns_ForbiddenError()
        {
            var client = GetAnonymousClient();

            var response = await client.Benchmark.GetComputedBenchmarkMetricsAsync();

            Assert.NotNull(response);
            Assert.False(response.Success);
            Assert.NotNull(response.Error);
        }

        [Fact]
        public async Task GetAllBenchmarkAlertsAsync_Returns_ComputedBenchmarkAlerts()
        {
            var client = GetBasicAuthClient();

            var response = await client.Benchmark.GetAllBenchmarkAlertsAsync();

            Assert.NotNull(response);
            Assert.True(response.Success);
        }

        [Fact(Skip = "Not working")]
        public async Task GetBenchmarkAlertsByTechnologiesAsync_Returns_ComputedBenchmarkAlerts()
        {
            var client = GetBasicAuthClient();

            var response = await client.Benchmark.GetBenchmarkAlertsByTechnologiesAsync();

            Assert.NotNull(response);
            Assert.True(response.Success);
        }

        [Fact]
        public async Task GetComputedBenchmarkMetricsAsync_Returns_Benchmark()
        {
            var client = GetBasicAuthClient();

            var response = await client.Benchmark.GetComputedBenchmarkMetricsAsync();

            Assert.NotNull(response);
            Assert.True(response.Success);
        }
    }
}