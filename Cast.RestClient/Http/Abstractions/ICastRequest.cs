namespace Cast.RestClient.Http.Abstractions
{
    public interface ICastRequest
    {
        Uri? RequestUri { get; }

        string ResourcePath { get; }

        HttpMethod Method { get; }

        ICastRequest BuildUri(string basePath);

        object? Body { get; }
    }
}