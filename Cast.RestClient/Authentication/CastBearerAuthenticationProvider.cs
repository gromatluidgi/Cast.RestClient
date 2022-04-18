using Cast.RestClient.Helpers;

namespace Cast.RestClient.Authentication
{
    public sealed class CastBearerAuthenticationProvider : CastAuthenticationProvider
    {
        public CastBearerAuthenticationProvider(string token)
        {
            Ensure.ArgumentNotNullOrEmptyString(token, nameof(token));

            Token = token;
        }

        public string Token { get; internal set; }

        public override string GetAuthorizationHeader()
        {
            return string.Format("Bearer {0}", Token);
        }

        protected override void DisposeUnmanagedObjects()
        {
            Token = string.Empty;
        }
    }
}