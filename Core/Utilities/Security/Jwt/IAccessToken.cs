using Newtonsoft.Json;
using System;

namespace Core.Utilities.Security.Jwt
{
    public interface IAccessToken
    {
        [JsonProperty("expiration")]
        DateTime Expiration { get; set; }
        [JsonProperty("token")]
        string Token { get; set; }
    }
}