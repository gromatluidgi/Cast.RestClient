using Cast.RestClient.Helpers;
using System.Text;

namespace Cast.RestClient.Authentication
{
    public sealed class CastBasicAuthenticationProvider : CastAuthenticationProvider
    {
        public CastBasicAuthenticationProvider(string login, string password)
        {
            Ensure.ArgumentNotNull(login, nameof(login));
            Ensure.ArgumentNotNull(password, nameof(password));

            Login = login;
            Password = password;
        }

        public string Login { get; internal set; }

        public string Password { get; internal set; }

        public override string GetAuthorizationHeader()
        {
            var credentialsChain = string.Format("{0}:{1}", Login, Password);
            var encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentialsChain));

            return string.Format("Basic {0}", encodedCredentials);
        }

        protected override void DisposeUnmanagedObjects()
        {
            Login = string.Empty;
            Password = string.Empty;
        }
    }
}