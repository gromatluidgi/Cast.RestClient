using Cast.RestClient.Extensions;
using System.Security;
using System.Text;

namespace Cast.RestClient.Authentication
{
    public sealed class CastBearerAuthenticationProvider : CastAuthenticationProvider
    {
        public CastBearerAuthenticationProvider(string token)
        {
            Token = IsValidToken(token);
        }

        public string Token { get; internal set;  }

        public override string GetAuthorizationHeader()
        {
            return string.Format("Bearer {0}", Token);
        }

        internal string IsValidToken(string token)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException(nameof(token));
            }
            return token;
        }

        protected override void DisposeUnmanagedObjects()
        {
            Token = string.Empty;

        }
    }
}