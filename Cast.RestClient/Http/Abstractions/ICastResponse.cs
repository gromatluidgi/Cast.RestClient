using System.Net;

namespace Cast.RestClient.Http.Abstractions
{
    public interface ICastResponse
    {
        ICastRequest? Request { get; internal set; }
        HttpContent? Content { get; }
        HttpStatusCode StatusCode { get; }
        CastError? Error { get; }
        bool Success { get; }
    }

    public interface ICastResponse<out T> : ICastResponse
    {
        T? Data { get; }
    }
}