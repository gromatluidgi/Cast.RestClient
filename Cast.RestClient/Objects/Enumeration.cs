using Cast.RestClient.Extensions;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Cast.RestClient.Objects
{
    public abstract class Enumeration : IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor should not be called from the derived class.
        /// It is helpful in doing JSON Serialization or mapping through Automapper.
        /// </remarks>
        [ExcludeFromCodeCoverage]
        protected Enumeration()
        {
            Name = string.Empty;
        }

        protected Enumeration(string name)
        {
            Name = name;
        }

        public string Name { get; }

        /// <summary>
        /// Gets all the instances of <typeparamref name="TEnumeration"/>.
        /// </summary>
        /// <typeparam name="TEnumeration">The type that inherits <see cref="Enumeration"/>.</typeparam>
        /// <returns>The list of <typeparamref name="TEnumeration"/>.</returns>
        public static IEnumerable<TEnumeration> GetAll<TEnumeration>()
            where TEnumeration : Enumeration
        {
            var fields = typeof(TEnumeration).GetFields(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<TEnumeration>();
        }

        /// <summary>
        /// Gets the instance of <typeparamref name="TEnumeration"/> from value or name.
        /// </summary>
        /// <typeparam name="TEnumeration">The type that inherits <see cref="Enumeration"/>.</typeparam>
        /// <param name="name">The <typeparamref name="TEnumeration"/> value or name.</param>
        /// <param name="enumeration">The <typeparamref name="TEnumeration"/> instance.</param>
        /// <returns>
        /// <c>true</c> if the instance <see cref="Enumeration"/> contains <typeparamref name="TEnumeration"/> with the specified name;
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool TryFromName<TEnumeration>(string name, out TEnumeration enumeration)
            where TEnumeration : Enumeration
        {
            return TryParse(item => string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase), out enumeration);
        }

        /// <summary>
        /// Gets the instance of <typeparamref name="T"/> from name.
        /// </summary>
        /// <typeparam name="T">The type that inherits <see cref="Enumeration"/>.</typeparam>
        /// <param name="name">Enumeration name.</param>
        /// <returns>The <typeparamref name="T"/> instance.</returns>
        /// <exception cref="InvalidOperationException">"<paramref name="name"/> is not valid".</exception>
        public static T FromName<T>(string name)
            where T : Enumeration
        {
            return Parse<T>(item => string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        private static bool TryParse<TEnumeration>(
            Func<TEnumeration, bool> predicate,
            out TEnumeration enumeration)
            where TEnumeration : Enumeration
        {
            enumeration = GetAll<TEnumeration>().FirstOrDefault(predicate);
            return enumeration != null!;
        }

        private static T Parse<T>(Func<T, bool> predicate)
            where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);
            if (ReferenceEquals(matchingItem, null))
            {
                throw new InvalidOperationException();
            }

            return matchingItem;
        }

        public static bool operator ==(Enumeration left, Enumeration right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Enumeration left, Enumeration right)
        {
            return !(left == right);
        }

        public static bool operator <(Enumeration left, Enumeration right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Enumeration left, Enumeration right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Enumeration left, Enumeration right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Enumeration left, Enumeration right)
        {
            return left.NullSafeCompareTo(right) >= 0;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                return -1;
            }

            return Name.CompareTo(((Enumeration)obj).Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            var otherValue = obj as Enumeration;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Name.Equals(otherValue!.Name);

            return typeMatches && valueMatches;
        }
    }
}