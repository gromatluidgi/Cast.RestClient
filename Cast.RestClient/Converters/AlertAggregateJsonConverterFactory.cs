using Cast.RestClient.Models.Aggregates;
using Cast.RestClient.Models.ValueObjects;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Converters
{
    /**
     * This converter provide a specialized recursive way to transform TopRiskAggregate json dictionary,
     * into <see cref="Aggregate"/> wrapped dictionary of generic KeyValuePair composed of abstract <see cref="IAlert"/>.
     */

    internal class AlertAggregateJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsClass
                && typeToConvert.IsSubclassOf(typeof(Aggregate));
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type keyType;
            Type valueType;

            if (typeToConvert.IsAssignableTo(typeof(Aggregate)) && typeToConvert.BaseType!.IsGenericType)
            {
                keyType = typeToConvert.BaseType.GetGenericArguments()[0];
                valueType = typeToConvert.BaseType.GetGenericArguments()[1];
            }
            else if (typeToConvert.IsAssignableTo(typeof(Aggregate)) && typeToConvert.GenericTypeArguments.Length > 0)
            {
                keyType = typeToConvert.GetGenericArguments()[0];
                valueType = typeToConvert.GetGenericArguments()[1];
            }
            else
            {
                throw new NotSupportedException("AlertAggregateJsonConverterFactory.CreateConverter() got called on a type that this converter factory doesn't support: " + nameof(typeToConvert));
            }

            var converterType = typeof(AlertAggregateJsonConverter<,>)
                .MakeGenericType(keyType, valueType);

            var converter = (JsonConverter)Activator.CreateInstance(converterType, args: new object[] { options })!;

            return converter;
        }

        private sealed class AlertAggregateJsonConverter<TKey, TValue> : JsonConverter<Aggregate<TKey, TValue>>
            where TKey : notnull
        {
            private readonly JsonConverter<TValue> _valueConverter;
            private readonly Type _valueType;

            public AlertAggregateJsonConverter(JsonSerializerOptions options)
            {
                _valueConverter = (JsonConverter<TValue>)options.GetConverter(typeof(TValue));
                _valueType = typeof(TValue);
            }

            public override Aggregate<TKey, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new FormatException();
                }

                var aggregate = (Aggregate<TKey, TValue>)Activator.CreateInstance(typeToConvert)!;

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

                    if (reader.TokenType == JsonTokenType.EndArray)
                    {
                        return aggregate;
                    }

                    TValue value;

                    if (reader.TokenType == JsonTokenType.StartObject)
                    {
                        var newOptions = CreateOptionsWithAlertConverter((string)key, options);
                        newOptions.Converters.Add(new AlertAggregateJsonConverterFactory().CreateConverter(_valueType, newOptions)!);
                        value = JsonSerializer.Deserialize<TValue>(ref reader, newOptions)!;
                    }
                    else
                    {
                        value = _valueConverter.Read(ref reader, _valueType, options)!;
                    }

                    aggregate.Data.Add((TKey)key!, value);
                }

                throw new FormatException();
            }

            public override void Write(Utf8JsonWriter writer, Aggregate<TKey, TValue> value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            private JsonSerializerOptions CreateOptionsWithAlertConverter(string key, JsonSerializerOptions options)
            {
                JsonSerializerOptions newOptions;
                if (key.Equals("topFilesAlert"))
                {
                    newOptions = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        Converters =
                        {
                            new AlertJsonConverterFactory(typeof(FileAlertResult)),
                        }
                    };
                    return newOptions;
                }
                else if (key.Equals("topRiskAlerts"))
                {
                    newOptions = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        Converters =
                        {
                            new AlertJsonConverterFactory(typeof(RiskAlertResult)),
                        }
                    };
                    return newOptions;
                }
                return new(options);
            }
        }
    }
}