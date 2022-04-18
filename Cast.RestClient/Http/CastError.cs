using System.Text.Json.Serialization;

namespace Cast.RestClient.Http
{
    public abstract class CastError
    {
        protected CastError()
        {
        }

        protected CastError(int? status, string message)
        {
            Status = status;
            Message = message ?? string.Empty;
        }

        public int? Status { get; set; }

        public virtual string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Status ?? -1}: {Message}";
        }
    }

    public class ApiError : CastError
    {
        public ApiError(int? status, string message)
            : base(status, message)
        {
        }
    }

    public class CastErrorModel<TEntity> : CastError
        where TEntity : class
    {
        public CastErrorModel()
        {
        }

        public CastErrorModel(int? status, string message)
            : base(status, message)
        {
        }

        [JsonPropertyName("entity")]
        public TEntity? Entity { get; set; }

        [JsonPropertyName("messageError")]
        public override string Message { get; set; } = string.Empty;
    }
}