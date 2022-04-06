using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cast.RestClient.Models.ValueObjects
{
    public class BenchmarkAlert
    {

        public BenchmarkAlert() { }

        [JsonPropertyName("min")]
        public double Minimum { get; set; }

        [JsonPropertyName("max")]
        public double Maximum { get; set; }

        [JsonPropertyName("avg")]
        public double Average { get; set; }

    }
}
