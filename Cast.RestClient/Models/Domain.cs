using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast.RestClient.Models
{
    public class Domain
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ClientRef { get; set; } = string.Empty;
        public Domain? Parent { get; set; }
    }
}
