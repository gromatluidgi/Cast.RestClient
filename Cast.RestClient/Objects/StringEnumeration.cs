using Cast.RestClient.Extensions;
using System.Reflection;

namespace Cast.RestClient.Objects
{
    public abstract class StringEnumeration : IComparable
    {
        protected StringEnumeration(string name)
        {
            Name = name;
        }

        public string Name { get; internal set; }

        public int CompareTo(object? obj)
        {
            if (obj == null) return -1;

            return Name.CompareTo(((StringEnumeration) obj).Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            var otherValue = obj as StringEnumeration;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Name.Equals(otherValue!.Name);

            return typeMatches && valueMatches;
        }

        public static IEnumerable<T> GetAll<T>() where T : StringEnumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();

        public static T FromName<T>(string name) where T : StringEnumeration
        {
            var matchingItem = Parse<T>(item => string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase));
            return matchingItem;
        }

        private static T Parse<T>(Func<T, bool> predicate) where T : StringEnumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);
            if (ReferenceEquals(matchingItem, null))
            {
                throw new InvalidOperationException();
            }

            return matchingItem;
        }

        public static bool operator ==(StringEnumeration left, StringEnumeration right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(StringEnumeration left, StringEnumeration right)
        {
            return !(left == right);
        }

        public static bool operator <(StringEnumeration left, StringEnumeration right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(StringEnumeration left, StringEnumeration right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(StringEnumeration left, StringEnumeration right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(StringEnumeration left, StringEnumeration right)
        {
            return left.NullSafeCompareTo(right) >= 0;
        }
    }
}