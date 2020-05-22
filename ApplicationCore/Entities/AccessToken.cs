using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ApplicationCore.Entities
{
    [Serializable]
    public class AccessToken : BaseEntity
    {
        public string ClientId { get; set; }
        [JsonPropertyName("access_token")]
        public string Token { get; set; }
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
