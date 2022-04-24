using Cast.RestClient.Attributes;

namespace Cast.RestClient.Extensions
{
    internal static class EnumExtensions
    {
        /// <summary>
        /// Retrieve string from enum attribute if exists.
        /// </summary>
        /// <param name="enumValue">Enum type with a potential <see cref="EnumValueAttribute"/>.</param>
        /// <returns>String from attribute value.</returns>
        internal static string GetStringValue(this Enum enumValue)
        {
            var stringValue = enumValue.ToString();

            var type = enumValue.GetType();
            var field = type.GetField(enumValue.ToString());
            var attrs = field.GetCustomAttributes(typeof(EnumValueAttribute), false);

            if (attrs.Length > 0)
            {
                stringValue = ((EnumValueAttribute[])attrs)[0].Value;
            }

            return stringValue;
        }
    }
}