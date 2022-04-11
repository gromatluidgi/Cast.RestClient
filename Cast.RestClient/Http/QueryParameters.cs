using Cast.RestClient.Extensions;
using System.Collections.Concurrent;
using System.Globalization;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Http
{
    public abstract class QueryParameters
    {
        static readonly ConcurrentDictionary<Type, List<QueryParameter>> _propertiesMap = new ConcurrentDictionary<Type, List<QueryParameter>>();

        /// <summary>
        /// Converts the derived object into a dictionary that can be used to supply query string parameters.
        /// </summary>
        /// <returns></returns>
        public virtual IDictionary<string, string> ToParametersDictionary()
        {
            var map = _propertiesMap.GetOrAdd(GetType(), GetPropertyParametersForType);
            return (from property in map
                    let value = property.GetValue(this)
                    let key = property.Key
                    where value != null
                    select new { key, value }).ToDictionary(kvp => kvp.key, kvp => kvp.value);
        }


        static List<QueryParameter> GetPropertyParametersForType(Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(p => new QueryParameter(p))
                .ToList();
        }

        static Func<PropertyInfo, object, string> GetValueFunc(Type propertyType)
        {
            // get underlying type if nullable
            propertyType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

            if (typeof(IEnumerable<string>).IsAssignableFrom(propertyType))
            {
                return (prop, value) =>
                {
                    var list = ((IEnumerable<string>)value).ToArray();
                    return list.Any() ? string.Join(",", list) : null!;
                };
            }

            if (propertyType.IsDateTimeOffset())
            {
                return (prop, value) =>
                {
                    if (value == null) return null!;
                    return ((DateTimeOffset)value).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ",
                      CultureInfo.InvariantCulture);
                };
            }

            if (propertyType.GetTypeInfo().IsEnum)
            {
                var enumToAttributeDictionary = Enum.GetNames(propertyType)
                    .ToDictionary(name => name, name => GetParameterAttributeValueForEnumName(propertyType, name));
                
                return (prop, value) =>
                {
                    if (value == null) return null!;
                    string attributeValue;

                    return enumToAttributeDictionary.TryGetValue(value.ToString()!, out attributeValue!)
                        ? attributeValue ?? value.ToString()!.ToLowerInvariant()
                        : value.ToString()!.ToLowerInvariant();
                };
            }

            return (prop, value) =>
            {
                if (value == null) return null!;
                return value.ToString()!;
            };
        }

        static string GetParameterAttributeValueForEnumName(Type enumType, string name)
        {
            var member = enumType.GetMember(name).FirstOrDefault();

            if (member == null) return null!;

            var attribute = member.GetCustomAttributes(typeof(JsonPropertyNameAttribute), false)
                .Cast<JsonPropertyNameAttribute>()
                .FirstOrDefault();


            return attribute == null ? null! :attribute.Name;
        }

        class QueryParameter
        {
            readonly Func<PropertyInfo, object, string> _valueFunc;
            readonly PropertyInfo _property;

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

            static string GetParameterKeyFromProperty(PropertyInfo property)
            {
                var attribute = property.GetCustomAttributes(typeof(JsonPropertyNameAttribute), false)
                    .Cast<JsonPropertyNameAttribute>()
                    .FirstOrDefault(attr => attr.Name != null);

                return attribute == null
                    ? property.Name.ToLowerInvariant()
                    : attribute.Name;
            }
        }
    }
}