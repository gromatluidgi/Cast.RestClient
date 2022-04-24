namespace Cast.RestClient.Models
{
    public class License
    {
        public License(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; }

        public string Name { get; }

        public string Compliance { get; set; } = string.Empty;
    }
}
