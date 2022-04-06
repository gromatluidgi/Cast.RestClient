using Cast.RestClient.Http.Abstractions;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Http
{
    public class CastResponse
    {
        public CastResponse(HttpResponseMessage message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            if (message.IsSuccessStatusCode)
            {
                StatusCode = message.StatusCode;
                Content = message.Content;
                Error = null;
            }
            else
            {
                Error = new ApiError((int)message.StatusCode, message.ReasonPhrase ?? string.Empty);
            }
        }

        public CastResponse(Exception exception)
        {
            Error = new ApiError(-1, exception.Message);
        }

        public HttpContent? Content { get; set; }
        public CastError? Error { get; internal set; }
        public HttpStatusCode StatusCode { get; }
        public bool Success => Error == null;
    }

    public class CastResponse<T> : CastResponse
    {
        public CastResponse(HttpResponseMessage message, ISerializer? serializer = default) : base(message)
        {
            if (serializer != null && Content != null)
            {
                Data = serializer.Deserialize<T>(Content.ReadAsByteArrayAsync().Result);
            }
        }

        public CastResponse(Exception exception) : base(exception)
        {
        }

        public T? Data { get; internal set; }

    }
}