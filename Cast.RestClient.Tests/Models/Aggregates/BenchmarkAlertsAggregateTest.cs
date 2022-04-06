using Cast.RestClient.Models.Aggregates;
using System.Text.Json;
using Xunit;

namespace Cast.RestClient.Tests.Models.Aggregates
{
    public class BenchmarkAlertsAggregateTest
    {
        [Fact]
        public void Should_Deserialize_From_Json()
        {
            const string json = @"{
                ""KSH"": {
                    ""softwareAgility"": [
                    {
                    ""technology"": {
                        ""id"": ""KSH"",
                        ""item"": ""KSH"",
                        ""display"": ""Ksh"",
                        ""color"": ""#dddf0d""
                    },
                    ""healthFactor"": ""softwareAgility"",
                    ""alert"": ""CommentedOutCode"",
                    ""min"": 0.006500000134110451,
                    ""max"": 17.5,
                    ""avg"": 1.08961351605282,
                    ""quartile1"": 0.4000000059604645,
                    ""quartile2"": 0.800000011920929,
                    ""quartile3"": 1.2527999877929688
                    }],
                    ""softwareResiliency"": [
                    {
                    ""technology"": {
                        ""id"": ""KSH"",
                        ""item"": ""KSH"",
                        ""display"": ""Ksh"",
                        ""color"": ""#dddf0d""
                    },
                    ""healthFactor"": ""softwareAgility"",
                    ""alert"": ""CommentedOutCode"",
                    ""min"": 0.006500000134110451,
                    ""max"": 17.5,
                    ""avg"": 1.08961351605282,
                    ""quartile1"": 0.4000000059604645,
                    ""quartile2"": 0.800000011920929,
                    ""quartile3"": 1.2527999877929688
                    }]
                },
                ""GO"": {
                    ""softwareAgility"": [
                    {
                    ""technology"": {
                        ""id"": ""KSH"",
                        ""item"": ""KSH"",
                        ""display"": ""Ksh"",
                        ""color"": ""#dddf0d""
                    },
                    ""healthFactor"": ""softwareAgility"",
                    ""alert"": ""CommentedOutCode"",
                    ""min"": 0.006500000134110451,
                    ""max"": 17.5,
                    ""avg"": 1.08961351605282,
                    ""quartile1"": 0.4000000059604645,
                    ""quartile2"": 0.800000011920929,
                    ""quartile3"": 1.2527999877929688
                    },
                    {
                    ""technology"": {
                        ""id"": ""KSH"",
                        ""item"": ""KSH"",
                        ""display"": ""Ksh"",
                        ""color"": ""#dddf0d""
                    },
                    ""healthFactor"": ""softwareAgility"",
                    ""alert"": ""ContinuationChar"",
                    ""min"": 0.006500000134110451,
                    ""max"": 17.5,
                    ""avg"": 1.08961351605282,
                    ""quartile1"": 0.4000000059604645,
                    ""quartile2"": 0.800000011920929,
                    ""quartile3"": 1.2527999877929688
                    }]
                }
            }";

            var aggregate = JsonSerializer.Deserialize<BenchmarkAlertsAggregate>(json);

            Assert.NotNull(aggregate);
            Assert.NotNull(aggregate!.Data);
            Assert.Equal(2, aggregate.Data.Count);
            Assert.NotEmpty(aggregate.Data["KSH"].Data);
            Assert.NotEmpty(aggregate.Data["GO"].Data);
        }
    }
}