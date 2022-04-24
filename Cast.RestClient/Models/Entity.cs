using Cast.RestClient.Helpers;

namespace Cast.RestClient.Models
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class Entity
    {
        public Entity(long id, string clientRef)
        {
            Ensure.ArgumentNotNull(id, nameof(id));
            Ensure.ArgumentNotNullOrEmptyString(clientRef, nameof(clientRef));

            Id = id;
            ClientRef = clientRef;
        }

        public long Id { get; }

        public string ClientRef { get; }
    }
}
