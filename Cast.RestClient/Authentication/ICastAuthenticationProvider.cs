using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast.RestClient.Authentication
{
    public interface ICastAuthenticationProvider
    {
        string GetAuthorizationHeader();
    }
}
