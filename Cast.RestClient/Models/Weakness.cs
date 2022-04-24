namespace Cast.RestClient.Models
{
    public class Weakness
    {
        public Weakness(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public string Label { get; set; } = string.Empty;
    }
}
