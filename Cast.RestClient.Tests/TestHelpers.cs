using Cast.RestClient.Http;
using Cast.RestClient.Http.Abstractions;
using Moq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Cast.RestClient.Tests
{
    public static class TestHelpers
    {
        public static readonly string FakeApiUrl = "https://fakeapi.com";

        public static ICastApiClient GetFakeApiClientWithResponse<T>(ICastResponse<T> response)
        {
            var client = new Mock<ICastApiClient>();
            client.Setup(c => c.BaseUri).Returns(FakeApiUrl);
            client.Setup(c => c.ExecuteCastRequestAsync<T>(It.IsAny<ICastRequest>(), It.IsAny<CancellationToken>()))
                .Returns((ICastRequest request, CancellationToken token) =>
                {
                    response.Request = request.BuildUri(client.Object.BaseUri);
                    return Task.FromResult(response);
                });
            return client.Object;
        }

        public static ICastApiClient GetFakeApiClientWithResponse(ICastResponse response)
        {
            var client = new Mock<ICastApiClient>();
            client.Setup(c => c.BaseUri).Returns(FakeApiUrl);
            client.Setup(c => c.ExecuteCastRequestAsync(It.IsAny<ICastRequest>(), It.IsAny<CancellationToken>()))
                .Returns((ICastRequest request, CancellationToken token) =>
                {
                    response.Request = request.BuildUri(client.Object.BaseUri);
                    return Task.FromResult(response);
                });
            return client.Object;
        }

        public static CastResponse<T> GetFakeResponse<T>(HttpStatusCode status = HttpStatusCode.OK)
        {
            var response = new CastResponse<T>(new HttpResponseMessage()
            {
                StatusCode = status,
            });
            return response;
        }

        public static CastResponse GetFakeResponse(HttpStatusCode status = HttpStatusCode.OK)
        {
            var response = new CastResponse(new HttpResponseMessage()
            {
                StatusCode = status,
            });
            return response;
        }
    }
}