using System;
using Patreon.Core.Domain;

namespace Patreon.Core
{
    public interface IAccessTokenSettings
    {
        string AccessToken { get; set; }

        Int64 Expire { get; set; }
        string RefreshToken { get; set; }
        string Scope { get; set; }
        string TokenType { get; set; }
        string Version { get; set; }
    }

    public class AccessTokenSettings : BaseSettings, IAccessTokenSettings
    {
        public AccessTokenSettings()
        {
        }

        public AccessTokenSettings(AccessTokenMessage dto)
        {
            AccessToken = dto.AccessToken;
            RefreshToken = dto.RefreshToken;
            Scope = dto.Scope;
            Expire = dto.Expire;
            TokenType = dto.TokenType;
            Version = dto.Version;
        }

        public string AccessToken { get; set; }
        public long Expire { get; set; }
        public string RefreshToken { get; set; }
        public string Scope { get; set; }
        public string TokenType { get; set; }
        public string Version { get; set; }
    }
}