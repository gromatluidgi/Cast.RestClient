using Cast.RestClient.Models.Aggregates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Converters
{
    /// <summary>
    /// Ugly dictionary of dictionary json converter
    /// </summary>
    public class AggregateJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsClass;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type keyType;
            Type valueType;

            if (typeToConvert.IsAssignableTo(typeof(Aggregate)) && typeToConvert.BaseType!.IsGenericType)
            {
                keyType = typeToConvert.BaseType.GetGenericArguments()[0];
                valueType = typeToConvert.BaseType.GetGenericArguments()[1];
            } else if (typeToConvert.IsAssignableTo(typeof(Aggregate)) && typeToConvert.GenericTypeArguments.Length > 0)
            {
                keyType = typeToConvert.GetGenericArguments()[0];
                valueType = typeToConvert.GetGenericArguments()[1];
            }
            else
            {
                throw new ArgumentException(nameof(typeToConvert));
            }

            var converterType = typeof(AggregateJsonConverter<,>)
                .MakeGenericType(keyType, valueType);

            var converter = (JsonConverter)Activator.CreateInstance(converterType, args: new object[] { options })!;

            return converter;
        }
    }

    internal class AggregateJsonConverter<TKey, TValue> : JsonConverter<Aggregate<TKey, TValue>>
        where TKey : notnull
    {
        private readonly JsonConverter<TValue> _baseConverter;
        private readonly Type _keyType;
        private readonly Type _valueType;

        public AggregateJsonConverter(JsonSerializerOptions options)
        {
            // For performance, use the existing converter if available.
            _baseConverter = (JsonConverter<TValue>)options
                .GetConverter(typeof(TValue));

            // Cache the key and value types.
            _keyType = typeof(TKey);
            _valueType = typeof(TValue);
        }

        public override Aggregate<TKey, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new FormatException();
            }

            var aggregate = (Aggregate<TKey, TValue>)Activator.CreateInstance(typeToConvert)!;

            if (aggregate == null)
            {
                throw new FormatException();
            }

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return aggregate;
                }

                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new FormatException();
                }

                object key = reader.GetString()!;

                reader.Read();

                TValue value;

                if (reader.TokenType == JsonTokenType.StartObject)
                {
                    var suboptions = new JsonSerializerOptions();
                    suboptions.PropertyNameCaseInsensitive = true;
                    suboptions.Converters.Add(new AggregateJsonConverterFactory().CreateConverter(_valueType, suboptions));
                    value = JsonSerializer.Deserialize<TValue>(ref reader, suboptions)!;
                }
                else
                {
                    value = JsonSerializer.Deserialize<TValue>(ref reader, options)!;
                }

                aggregate.Data.Add((TKey)key!, value);
            }

            throw new FormatException();
        }

        public override void Write(Utf8JsonWriter writer, Aggregate<TKey, TValue> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}