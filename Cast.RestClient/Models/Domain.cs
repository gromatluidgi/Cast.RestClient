﻿namespace Cast.RestClient.Models
{
    public class Domain
    {
        public Domain()
        {
        }

        public Domain(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ClientRef { get; set; } = string.Empty;

        public Domain? Parent { get; set; }

        internal static Domain Null => new();
    }
}