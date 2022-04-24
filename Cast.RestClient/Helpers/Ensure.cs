using Cast.RestClient.Extensions;

namespace Cast.RestClient.Helpers
{
    internal static class Ensure
    {
        public static void ArgumentNotNull(object value, string name)
        {
            if (value != null)
            {
                return;
            }

            throw new ArgumentNullException(name);
        }

        public static void IsEnumerable(object value, string name)
        {
            ArgumentNotNull(value, name);

            if (value.GetType().IsGenericEnumerable())
            {
                return;
            }

            throw new ArgumentException("Value must be an enumerable", name);
        }

        public static void IsArray(object value, string name)
        {
            ArgumentNotNull(value, name);

            if (value.GetType().IsArray)
            {
                return;
            }

            throw new ArgumentException("Value must be an array", name);
        }

        public static void IsConvertibleToString(object value, string name)
        {
            ArgumentNotNull(value, name);

            if (value.GetType().IsStringConvertible())
            {
                return;
            }

            throw new ArgumentException("Value must be a simple type (primitive, string, enum...)", name);
        }

        /// <summary>
        /// Checks a string argument to ensure it isn't null or empty.
        /// </summary>
        /// <param name = "value">The argument value to check.</param>
        /// <param name = "name">The name of the argument.</param>
        public static void ArgumentNotNullOrEmptyString(string value, string name)
        {
            ArgumentNotNull(value, name);

            if (!string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            throw new ArgumentException("String cannot be empty", name);
        }

        public static void ValidApiUrl(string url, bool secureOnly)
        {
            ArgumentNotNull(url, nameof(url));

            Uri uriResult;
            var result = Uri.TryCreate(url, UriKind.Absolute, out uriResult!);

            if (!result)
            {
                throw new ArgumentException(nameof(url));
            }

            if (secureOnly && uriResult.Scheme != Uri.UriSchemeHttps)
            {
                throw new ArgumentException("HTTPS is required", nameof(url));
            }

            if (!secureOnly && uriResult.Scheme != Uri.UriSchemeHttp)
            {
                throw new ArgumentException("Unsupported uri protocol", nameof(url));
            }

            return;
        }
    }
}