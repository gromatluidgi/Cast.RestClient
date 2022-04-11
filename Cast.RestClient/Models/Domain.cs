namespace Cast.RestClient.Models
{
    public class Domain
    {
        internal static Domain Null
        {
            get { return new Domain(); }
        }

        public Domain()
        { }

        public Domain(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ClientRef { get; set; } = string.Empty;
        public Domain? Parent { get; set; }
    }
}