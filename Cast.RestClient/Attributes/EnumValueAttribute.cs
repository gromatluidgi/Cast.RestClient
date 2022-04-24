namespace Cast.RestClient.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal sealed class EnumValueAttribute : Attribute
    {
        public EnumValueAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}