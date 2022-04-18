namespace Cast.RestClient.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal sealed class QueryParameterAttribute : Attribute
    {
        private readonly string _name;

        public QueryParameterAttribute(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
