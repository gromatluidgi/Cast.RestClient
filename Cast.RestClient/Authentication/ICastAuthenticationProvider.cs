namespace Cast.RestClient.Authentication
{
    public interface ICastAuthenticationProvider
    {
        string GetAuthorizationHeader();
    }
}