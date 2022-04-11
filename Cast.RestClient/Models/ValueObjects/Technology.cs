using Cast.RestClient.Objects;

namespace Cast.RestClient.Models.ValueObjects
{
    public class Technology : StringEnumeration
    {
        public static readonly Technology KSH = new Technology("KSH");
        public static readonly Technology GO = new Technology("GO");

        private Technology(string name) : base(name)
        {
        }
    }
}