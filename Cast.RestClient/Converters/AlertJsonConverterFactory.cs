using Cast.RestClient.Models.Abstractions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Converters
{
    internal class AlertJsonConverterFactory : JsonConverterFactory
    {
        public AlertJsonConverterFactory(Type concrete)
        {
            ConcreteType = concrete;
        }

        public Type ConcreteType { get; }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsAssignableFrom(typeof(IAlert));
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return new AlertJsonConverter<IAlert>(ConcreteType);
        }

        private sealed class AlertJsonConverter<TAlert> : JsonConverter<TAlert>
        {
            private readonly Type _concreteType;

            public AlertJsonConverter(Type concreteType)
            {
                _concreteType = concreteType;
            }

            public override TAlert? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new FormatException();
                }

                return (TAlert?)JsonSerializer.Deserialize(ref reader, _concreteType, options);
            }

            public override void Write(Utf8JsonWriter writer, TAlert value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}