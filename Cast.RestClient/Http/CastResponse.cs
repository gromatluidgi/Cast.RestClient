using Cast.RestClient.Http.Abstractions;
using System.Diagnostics;
using System.Net;

namespace Cast.RestClient.Http
{
    public class CastResponse : ICastResponse
    {
        public CastResponse(HttpResponseMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

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

        public HttpContent? Content { get; }

        public CastError? Error { get; internal set; }

        public ICastRequest? Request { get; set; }

        public HttpStatusCode StatusCode { get; }

        public bool Success => Error == null;
    }

    public class CastResponse<T> : CastResponse, ICastResponse<T>
    {
        public CastResponse(HttpResponseMessage message, ISerializer? serializer = default)
            : base(message)
        {
            if (serializer != null && CanDeserializeContent())
            {
#if DEBUG
                var watch = Stopwatch.StartNew();
#endif
                Data = serializer.Deserialize<T>(Content!.ReadAsStringAsync().Result);
#if DEBUG
                watch.Stop();
                Console.WriteLine($"Elapsed time for deserializing data from JSON: {watch.ElapsedMilliseconds}");
#endif
            }
        }

        public CastResponse(Exception exception)
            : base(exception)
        {
        }

        public T? Data { get; internal set; }

        private bool CanDeserializeContent()
        {
            if (Content == null)
            {
                return false;
            }

            if (Content.Headers.ContentLength == 0)
            {
                return false;
            }

            return true;
        }
    }
}