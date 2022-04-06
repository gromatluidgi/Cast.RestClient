using Cast.RestClient.Extensions;
using System.Security;
using System.Text;

namespace Cast.RestClient.Authentication
{
    public sealed class CastBasicAuthenticationProvider : CastAuthenticationProvider
    {
        public CastBasicAuthenticationProvider(string login, string password)
        {
            Login = IsValidLogin(login);
            Password = IsValidPassword(password);
        }

        public string Login { get; internal set; }
        public string Password { get; internal set; }

        public override string GetAuthorizationHeader()
        {
            var credentialsChain = string.Format("{0}:{1}", Login, Password);
            var encodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentialsChain));

            return string.Format("Basic {0}", encodedCredentials);
        }

        internal string IsValidLogin(string login)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException(nameof(login));
            }
            return login;
        }

        internal string IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException(nameof(password));
            }
            return password;
        }

        protected override void DisposeUnmanagedObjects()
        {
            Login = string.Empty;
            Password = string.Empty;
        }
    }
}