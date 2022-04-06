using Cast.RestClient.Http.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cast.RestClient.Http
{
    public class CustomJsonSerializer : ISerializer
    {
        public T? Deserialize<T>(byte[] value)
        {
            if (value == null)
                return default(T);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(value, options);
        }

        public byte[] Serialize(object item)
        {
            throw new NotImplementedException();
        }
    }
}
