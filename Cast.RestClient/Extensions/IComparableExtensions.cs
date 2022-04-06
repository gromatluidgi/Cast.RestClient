namespace Cast.RestClient.Extensions
{
    public static class IComparableExtensions
    {
        /// <summary>
        /// Compare an IComparable{T} with a {T}. If both are null, zero is returned. If this object is
        /// null, -1 is returned. If the object to compare with is null, 1 is returned. Otherwise, this
        /// object's <c>CompareTo</c> is called with the object to compare to as its parameter.
        /// </summary>
        /// <returns>The comparison of this object with the parameter</returns>
        /// <param name="a">The object to compare against <c>b</c></param>
        /// <param name="b">The object to compare with</param>
        /// <typeparam name="T">The type of object to compare with</typeparam>
        public static int NullSafeCompareTo<T>(this IComparable<T> a, T b)
        {
            return a == null ? ZeroIfNull(b) : CompareIfNotNull(b,a);
        }

        /// <summary>
        /// Compare an IComparable with an object. If both are null, zero is returned. If this object is
        /// null, -1 is returned. If the object to compare with is null, 1 is returned. Otherwise, this
        /// object's <c>CompareTo</c> is called with the object to compare to as its parameter.
        /// </summary>
        /// <returns>The comparison of this object with the parameter</returns>
        /// <param name="a">The object to compare against <c>b</c></param>
        /// <param name="b">The object to compare with</param>
        public static int NullSafeCompareTo(this IComparable a, object b)
        {
            return a == null ? ZeroIfNull(b) : CompareIfNotNull(b, a);
        }

        private static int ZeroIfNull<T>(T? nullable)
        {
            if (nullable == null) return 0;
            return -1;
        }

        private static int CompareIfNotNull<T>(T? nullable, IComparable<T> comparer)
        {
            if (nullable == null) return 1;
            return comparer.CompareTo(nullable);
        }

        private static int CompareIfNotNull<T>(T? nullable, IComparable comparer)
        {
            if (nullable == null) return 1;
            return comparer.CompareTo(nullable);
        }
    }
}