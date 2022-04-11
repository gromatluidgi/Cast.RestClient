using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Converters
{
    internal class EnumerableJsonFactoryConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return true;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type keyType = typeToConvert.GetGenericArguments()[0];
            var converterType = typeof(EnumerableJsonConverter<>).MakeGenericType(keyType);
            var converter = (JsonConverter)Activator.CreateInstance(converterType)!;
            return converter;
        }

        internal class EnumerableJsonConverter<T> : JsonConverter<IEnumerable<T>>
        {
            public override IEnumerable<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartArray)
                {
                    throw new FormatException();
                }

                var enumarable = Enumerable.Empty<T>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndArray)
                    {
                        return enumarable;
                    }

                    T value = JsonSerializer.Deserialize<T>(ref reader, options)!;

                    if (value == null)
                        throw new FormatException();

                    enumarable = enumarable.Append(value!);
                }

                throw new FormatException();
            }

            public override void Write(Utf8JsonWriter writer, IEnumerable<T> value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}