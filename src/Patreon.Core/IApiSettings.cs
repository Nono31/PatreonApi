namespace Patreon.Core
{
    public interface IApiSettings
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }
        string AccessToken { get; set; }
        string RedirectUrl { get; set; }
    }

    public class ApiSettings : BaseSettings, IApiSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AccessToken { get; set; }
        public string RedirectUrl { get; set; }
    }
    }