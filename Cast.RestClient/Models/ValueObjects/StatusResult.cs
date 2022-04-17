namespace Cast.RestClient.Models.ValueObjects
{
    public class StatusResult<TResult, TError>
        where TResult : notnull
        where TError : notnull
    {
        public TResult? Result { get; set; }

        public TError? Error { get; set; }
    }
}