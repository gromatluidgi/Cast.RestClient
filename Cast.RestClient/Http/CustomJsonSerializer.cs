using Cast.RestClient.Http.Abstractions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Http
{
    public class CustomJsonSerializer : ISerializer
    {
        private readonly JsonSerializerOptions _options;

        public CustomJsonSerializer()
        {
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.Never
            };
        }

        public T? Deserialize<T>(byte[] value)
        {
            if (value == null)
                return default(T);

            return JsonSerializer.Deserialize<T>(value, _options);
        }

        public T? Deserialize<T>(string value)
        {
            if (value == null)
                return default(T);

            return JsonSerializer.Deserialize<T>(value, _options);
        }

        public byte[] Serialize(object item)
        {
            throw new NotImplementedException();
        }
    }
}