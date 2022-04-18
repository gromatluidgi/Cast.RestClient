namespace Cast.RestClient.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsDateTimeOffset(this Type type)
        {
            return type == typeof(DateTimeOffset) || type == typeof(DateTimeOffset?);
        }

        public static bool IsGenericEnumerable(this Type type)
        {
            if (type.GetGenericArguments().Length == 0)
            {
                return false;
            }

            return type.GetInterfaces()
                       .Any(s => s.Name == "IEnumerable");
        }

        public static bool IsStringConvertible(this Type type)
        {
            return
                type.IsPrimitive ||
                new Type[]
                {
                    typeof(string),
                    typeof(decimal),
                    typeof(DateTime),
                    typeof(DateTimeOffset),
                    typeof(DateTimeOffset?),
                    typeof(TimeSpan),
                    typeof(Guid),
                }.Contains(type) ||
                type.IsEnum;
        }
    }
}