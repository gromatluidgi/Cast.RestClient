# Cast.RestClient
 
![Build status](https://github.com/gromatluidgi/Cast.RestClient/workflows/Dotnet%20Build/badge.svg)
[![Build status](https://ci.appveyor.com/api/projects/status/gr3t4g274p4t9kwg/branch/main?svg=true)](https://ci.appveyor.com/project/gromatluidgi/cast-restclient/branch/main)
[![codecov](https://codecov.io/gh/gromatluidgi/Cast.RestClient/branch/main/graph/badge.svg?token=R8ALLT5FRQ)](https://codecov.io/gh/gromatluidgi/Cast.RestClient)

Cast.RestClient is a library that provides an easy way to interact with the
[Cast Hightlight API](https://rpa.casthighlight.com/api-doc/index.html).

## TODO

- Implements every endpoints
- Allow custom http client/proxy
- Custom serializer

## Usage

Authentication is **mandatory** for query any resources provided by Cast API.

### Basic Authentication

```c#
var options = new CastRestClientOptions("https://demo.casthighlight.com/WS2/");
var authProvider = new CastBasicAuthenticationProvider("login", "password");
var castClient = new CastRestClient(authProvider, options);

var response = await castClient.Domain.GetDomainByIdAsync(0);
if (response.Success){
    var domain = response.Data;
    Console.WriteLine("Domain name: " + domain.Name);
} else {
    Console.WriteLine(response.Error!.Message)
}
```

### Token Authentication

```c#
var options = new CastRestClientOptions("https://demo.casthighlight.com/WS2/");
var authProvider = new CastBearerAuthenticationProvider("access_token");
var castClient = new CastRestClient(authProvider, options);
```

### Dependency Injection

```c#
var options = new CastRestClientOptions("https://demo.casthighlight.com/WS2/");
var authProvider = new CastBearerAuthenticationProvider("access_token");

var service = new ServiceCollection();
service.AddCastRestClient(authProvider, options);
```

## Build

Cast.RestClient is a single assembly designed to be easy to deploy anywhere.

To clone and build it locally click the "Clone in Desktop" button above or run the following git commands.

```
git clone git@github.com:gromatluidgi/Cast.RestClient.git CastRestClient
cd CastRestClient
dotnet build
```

## Test

```
dotnet test
```