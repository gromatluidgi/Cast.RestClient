using Cast.RestClient.Extensions;
using System.Text;

namespace Cast.RestClient.Helpers
{
    internal static class QueryHelper
    {
        /// <summary>
        /// Converts an enumerable list of data into a Cast API query parameter array.
        /// </summary>
        /// <param name="paramName">HTTP Query parameter name.</param>
        /// <param name="values">Parameter values.</param>
        /// <returns>A strings chain representing an array of data in http query.</returns>
        internal static string ParametersFromDynamicEnumerable(string paramName, object values)
        {
            Ensure.ArgumentNotNullOrEmptyString(paramName, nameof(paramName));
            Ensure.IsEnumerable(values, nameof(values));

            dynamic enumerable = values;

            if (enumerable!.Count == 0)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            var enumerator = enumerable!.GetEnumerator();
            var value = enumerator.MoveNext();
            var currentValue = ParameterFromObject(enumerator.Current);
            stringBuilder.Append(string.Format("{0}", currentValue));

            while (value)
            {
                value = enumerator.MoveNext();
                if (value)
                {
                    stringBuilder.Append("&");
                    currentValue = ParameterFromObject(enumerator.Current);
                    stringBuilder.Append(string.Format("{0}={1}", paramName, currentValue));
                }
            }

            return stringBuilder.ToString();
        }

        internal static string ParametersFromDynamicArray(string paramName, object values)
        {
            Ensure.ArgumentNotNullOrEmptyString(paramName, nameof(paramName));
            Ensure.IsArray(values, nameof(values));

            return ParametersFromDynamicEnumerable(paramName, ObjectConverter.ArrayObjectToGenericList(values));
        }

        /// <summary>
        /// Transform a simple type object to a valid query parameter string value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>String representation of given value.</returns>
        internal static string ParameterFromObject(object value)
        {
            Ensure.ArgumentNotNull(value, nameof(value));
            Ensure.IsConvertibleToString(value, nameof(value));

            if (value.GetType().IsEnum)
            {
                return ((Enum)value).GetStringValue();
            }

            return value.ToString();
        }
    }
}
