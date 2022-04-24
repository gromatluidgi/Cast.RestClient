using System.Collections.Concurrent;
using System.Reflection;

namespace Cast.RestClient.Http.Queries
{
    public abstract class QueryParameters
    {
        private static readonly ConcurrentDictionary<Type, List<QueryParameter>> _propertiesMap =
            new();

        /// <summary>
        /// Retrieve any public properties from instance type.
        /// </summary>
        /// <param name="type">Instance type.</param>
        /// <returns>List of property converted into parameters.</returns>
        internal static List<QueryParameter> GetPropertyParametersForType(Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(p => new QueryParameter(p))
                .ToList();
        }

        /// <summary>
        /// Converts the derived object into a dictionary that can be used to supply query string parameters.
        /// </summary>
        internal virtual IDictionary<string, string> ToParametersDictionary()
        {
            var map = _propertiesMap.GetOrAdd(GetType(), GetPropertyParametersForType);
            return (from property in map
                    let value = property.GetValue(this)
                    let key = property.Key
                    where value != null
                    select new { key, value }).ToDictionary(kvp => kvp.key, kvp => kvp.value);
        }
    }
}