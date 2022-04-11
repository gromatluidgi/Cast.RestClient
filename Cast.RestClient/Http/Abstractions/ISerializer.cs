namespace Cast.RestClient.Http.Abstractions
{
    public interface ISerializer
    {
        byte[] Serialize(object item);

        T? Deserialize<T>(byte[] value);

        T? Deserialize<T>(string value);
    }
}