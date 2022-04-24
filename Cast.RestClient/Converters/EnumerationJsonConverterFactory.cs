using Cast.RestClient.Objects;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Converters
{
    internal sealed class EnumerationJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsSubclassOf(typeof(Enumeration));
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converterType = typeof(EnumerationConverter<>).MakeGenericType(typeToConvert);

            return (JsonConverter)Activator.CreateInstance(converterType)!;
        }

        internal sealed class EnumerationConverter<T> : JsonConverter<T>
            where T : Enumeration
        {
            public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var token = reader.TokenType;

                if (token == JsonTokenType.String)
                {
                    var enumString = reader.GetString()!;

                    return (T)GetEnumerationFromJson(enumString, typeToConvert);
                }

                throw new FormatException();
            }

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            internal static Enumeration GetEnumerationFromJson(string name, Type objectType)
            {
                try
                {
                    object result = default!;
                    var methodInfo = typeof(Enumeration).GetMethod(
                        nameof(Enumeration.TryFromName),
                        BindingFlags.Static | BindingFlags.Public);

                    if (methodInfo == null)
                    {
                        throw new JsonException("Serialization is not supported");
                    }

                    var genericMethod = methodInfo.MakeGenericMethod(objectType);
                    var arguments = new[] { name, result };

                    genericMethod.Invoke(null, arguments);

                    return (Enumeration)arguments[1]!;
                }
                catch (Exception ex)
                {
                    throw new JsonException($"Error converting value '{name}' to a enumeration.", ex);
                }
            }
        }
    }
}