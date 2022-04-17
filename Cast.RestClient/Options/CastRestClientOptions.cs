using Cast.RestClient.Helpers;

namespace Cast.RestClient.Options
{
    public class CastRestClientOptions
    {
        public CastRestClientOptions(string highlightApiUrl, bool secureOnly = true)
        {
            Ensure.ValidApiUrl(highlightApiUrl, secureOnly);

            HighlightApiUrl = highlightApiUrl;
        }

        public string HighlightApiUrl { get; internal set; }

        public long DomainId { get; set; }
    }
}