using Cast.RestClient.Attributes;
using Cast.RestClient.Http.Queries;

namespace Cast.RestClient.Clients.Applications.Queries
{
    public class ApplicationQuery : QueryParameters
    {
        public ApplicationQuery()
            : this(0, 0)
        {
        }

        public ApplicationQuery(int maxEntryPerPage, int pageOffset, IEnumerable<ApplicationExpand>? expands = default)
        {
            MaxEntryPerPage = maxEntryPerPage;
            PageOffset = pageOffset;
            LoadExpands(expands!);
        }

        [QueryParameter("maxEntryPerPage")]
        public int MaxEntryPerPage { get; }

        [QueryParameter("pageOffset")]
        public int PageOffset { get; }

        [QueryParameter("expand")]
        public HashSet<ApplicationExpand>? Expands { get; private set; }

        internal void LoadExpands(IEnumerable<ApplicationExpand> expands)
        {
            if (expands == null || !expands.Any())
            {
                return;
            }

            Expands = new HashSet<ApplicationExpand>(expands);
        }
    }
}