namespace Cast.RestClient.Models.Aggregates
{
    public class Aggregate
    {
        public Aggregate()
        {
        }
    }

    public class Aggregate<TKey, TValue> : Aggregate
        where TKey : notnull
    {
        public Aggregate()
        {
            Data = new Dictionary<TKey, TValue>();
        }

        public IDictionary<TKey, TValue> Data { get; internal set; }
    }
}