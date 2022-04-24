using Cast.RestClient.Attributes;
using Cast.RestClient.Extensions;
using Cast.RestClient.Helpers;
using System.Globalization;
using System.Reflection;

namespace Cast.RestClient.Http.Queries
{
    internal class QueryParameter
    {
        private readonly Func<PropertyInfo, object, string> _valueFunc;
        private readonly PropertyInfo _property;

        public QueryParameter(PropertyInfo property)
        {
            _property = property;
            Key = GetParameterKeyFromProperty(property);
            _valueFunc = GetValueFunc(property.PropertyType);
        }

        public string Key { get; private set; }

        public string GetValue(object instance)
        {
            return _valueFunc(_property, _property.GetValue(instance, null)!);
        }

        /// <summary>
        /// Convert the given property type to http query string parameter.
        /// </summary>
        /// <param name="propertyType">The type to convert.</param>
        /// <returns>The type converted to a compatible http query string.</returns>
        internal static Func<PropertyInfo, object, string> GetValueFunc(Type propertyType)
        {
            // get underlying type if nullable
            propertyType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

            if (propertyType.IsGenericEnumerable())
            {
                return (prop, value) =>
                {
                    return QueryHelper.ParametersFromDynamicEnumerable(prop.Name, value);
                };
            }

            if (propertyType.IsArray)
            {
                return (prop, value) =>
                {
                    return QueryHelper.ParametersFromDynamicEnumerable(prop.Name, value);
                };
            }

            if (propertyType.IsDateTimeOffset())
            {
                return (prop, value) =>
                {
                    if (value == null)
                    {
                        return null!;
                    }

                    return ((DateTimeOffset)value).ToUniversalTime().ToString(
                        "yyyy-MM-ddTHH:mm:ssZ",
                        CultureInfo.InvariantCulture);
                };
            }

            return (prop, value) =>
            {
                if (value == null)
                {
                    return null!;
                }

                return QueryHelper.ParameterFromObject(value);
            };
        }

        private static string GetParameterKeyFromProperty(PropertyInfo property)
        {
            var attribute = property.GetCustomAttributes(typeof(QueryParameterAttribute), false)
                .Cast<QueryParameterAttribute>()
                .FirstOrDefault(attr => attr.Name != null);

            return attribute == null
                ? property.Name.ToLowerInvariant()
                : attribute.Name;
        }
    }
}
