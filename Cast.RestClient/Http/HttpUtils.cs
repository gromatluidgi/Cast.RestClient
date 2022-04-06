namespace Cast.RestClient.Http
{
    public static class HttpUtils
    {
        public static HttpMethod Parse(string methodName)
        {
            switch (methodName.ToUpperInvariant())
            {
                case "GET":
                    return HttpMethod.Get;

                case "POST":
                    return HttpMethod.Post;

                case "PUT":
                    return HttpMethod.Put;

                case "DELETE":
                    return HttpMethod.Delete;

                default:
                    throw new ArgumentException("cannot parse '" + methodName + "' as a http method");
            }
        }
    }
}