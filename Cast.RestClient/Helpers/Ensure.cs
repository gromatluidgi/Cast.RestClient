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
            bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult!);

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