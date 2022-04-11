namespace Cast.RestClient.Models.ValueObjects
{
    public class BusinessDate
    {
        public static BusinessDate Null
        {
            get { return new BusinessDate(); }
        }

        public long Time { get; protected set; }
    }
}