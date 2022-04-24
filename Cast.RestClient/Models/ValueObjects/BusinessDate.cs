namespace Cast.RestClient.Models.ValueObjects
{
    public class BusinessDate
    {
        public static BusinessDate Null => new();

        public long Time { get; protected set; }
    }
}