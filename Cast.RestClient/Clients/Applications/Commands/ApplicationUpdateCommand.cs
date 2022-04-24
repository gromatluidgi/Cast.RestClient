using Cast.RestClient.Helpers;
using Cast.RestClient.Models;
using System.Diagnostics.CodeAnalysis;

namespace Cast.RestClient.Clients.Applications.Commands
{
    [ExcludeFromCodeCoverage]
    public class ApplicationUpdateCommand
    {
        public ApplicationUpdateCommand(string name)
        {
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));
            Name = name;
        }

        public long Id { get; set; }

        public string ClientRef { get; set; } = string.Empty;

        public string Name { get; }

        public IEnumerable<Entity> Contributors { get; } = Enumerable.Empty<Entity>();

        public IEnumerable<Entity> Domains { get; } = Enumerable.Empty<Entity>();

        public IEnumerable<Tag> Tags { get; } = Enumerable.Empty<Tag>();

        public IEnumerable<Survey> Surveys { get; } = Enumerable.Empty<Survey>();
    }
}
