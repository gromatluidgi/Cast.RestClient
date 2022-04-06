namespace Cast.RestClient.Http
{
    public abstract class CastError
    {
        public int? Status { get; set; }
        public string Message { get; set; }

        protected CastError(int? status, string message)
        {
            Status = status;
            Message = message;
        }

        public override string ToString()
        {
            return $"{Status}: {Message}";
        }
    }

    public class ApiError : CastError
    {
        public ApiError(int? status, string message) : base(status, message)
        {
        }
    }
}