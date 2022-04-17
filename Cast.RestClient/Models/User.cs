﻿namespace Cast.RestClient.Models
{
    public class User
    {
        public long Id { get; set; }

        public string? ClientRef { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
    }
}