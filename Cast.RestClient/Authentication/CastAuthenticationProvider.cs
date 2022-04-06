namespace Cast.RestClient.Authentication
{
    /*
     * Why SecureString should not be used for storing crendentials.
     * https://docs.microsoft.com/fr-fr/dotnet/api/system.security.securestring?view=net-6.0#remarks
     */
    public abstract class CastAuthenticationProvider : Disposable, ICastAuthenticationProvider
    {
        public abstract string GetAuthorizationHeader();
    }
}