using System.Net.Http.Headers;

namespace Cast.RestClient.Extensions
{
    public static class HttpMessageExtensions
    {
        public static void SetJsonRequestHeaders(this HttpRequestMessage httpMessage)
        {
            if (httpMessage.Content != null)
            {
                httpMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
            httpMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}