using Cast.RestClient.Http.Abstractions;

namespace Cast.RestClient.Options
{
    public class CastRestClientOptions
    {
        public CastRestClientOptions(string highlightApiUrl)
        {
            HighlightApiUrl = ValidateApiUrl(highlightApiUrl);
        }

        public bool IsDebug { get; set; } = false;

        /// <summary>
        /// Indicates if the client should only use https. Default is true.
        /// </summary>
        public bool IsSecureOnly { get; set; } = true;

        public string HighlightApiUrl { get; internal set; }

        public long DomainId { get; set; }

        public ISerializer? Serializer { get; set; }

        private string ValidateApiUrl(string apiUrl)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(apiUrl, UriKind.Absolute, out uriResult!);

            if (uriResult == null)
                throw new ArgumentException(nameof(apiUrl));

            if (!result)
                throw new ArgumentException(nameof(apiUrl));

            if (IsSecureOnly && uriResult.Scheme != Uri.UriSchemeHttps)
                throw new ArgumentException(nameof(apiUrl));

            return apiUrl;
        }
    }
}