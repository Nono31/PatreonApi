using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Patreon.Api.Domain
{
    public class AccessTokenReponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public Int64 Expire { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}