namespace Cast.RestClient.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsDateTimeOffset(this Type type)
        {
            return type == typeof(DateTimeOffset) || type == typeof(DateTimeOffset?);
        }
    }
}