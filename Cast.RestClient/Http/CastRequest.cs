using Cast.RestClient.Http.Abstractions;
using Cast.RestClient.Http.Queries;
using Microsoft.AspNetCore.WebUtilities;

namespace Cast.RestClient.Http
{
    public class CastRequest : ICastRequest
    {
        public CastRequest(HttpMethod method, string path, QueryParameters? parameters = default)
        {
            Method = method;
            ResourcePath = path;
            Parameters = parameters;
        }

        public CastRequest(HttpMethod method, string path, object body, QueryParameters? parameters = default)
        {
            Method = method;
            ResourcePath = path;
            Body = body;
            Parameters = parameters;
        }

        public QueryParameters? Parameters { get; }

        public HttpMethod Method { get; }

        public string ResourcePath { get; }

        public Uri? RequestUri { get; internal set; }

        public object? Body { get; internal set; }

        public ICastRequest BuildUri(string basePath)
        {
            var path = string.Join("/", basePath, ResourcePath);

            if (Parameters == null)
            {
                RequestUri = new Uri(path);
            }
            else
            {
                RequestUri = new Uri(QueryHelpers.AddQueryString(path, Parameters.ToParametersDictionary()));
            }

            return this;
        }
    }
}