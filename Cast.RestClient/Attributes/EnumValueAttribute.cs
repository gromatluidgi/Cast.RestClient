namespace Cast.RestClient.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal sealed class EnumValueAttribute : Attribute
    {
        private readonly string _value;

        public EnumValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }
}