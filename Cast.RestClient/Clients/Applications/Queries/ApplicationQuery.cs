using Cast.RestClient.Http;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Clients.Applications.Queries
{
    public class ApplicationQuery : QueryParameters
    {
        public ApplicationQuery()
        {
        }

        public ApplicationQuery(int maxEntryPerPage, int pageOffset, IEnumerable<ApplicationExpand>? expands = default)
        {
            MaxEntryPerPage = maxEntryPerPage;
            PageOffset = pageOffset;
            LoadExpands(expands!);
        }

        public int MaxEntryPerPage { get; }

        public int PageOffset { get; }

        [JsonPropertyName("expand")]
        public HashSet<ApplicationExpand>? Expands { get; internal set; }

        private void LoadExpands(IEnumerable<ApplicationExpand> expands)
        {
            if (expands == null)
            {
                return;
            }

            Expands = new HashSet<ApplicationExpand>(expands);
        }
    }
}