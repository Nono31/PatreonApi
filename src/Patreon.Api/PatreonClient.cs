using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Patreon.Core;
using Patreon.Core.Domain;

namespace Patreon.Api
{
    public class PatreonClient
    {
        private AccessTokenSettings _accessTokenSettings;
        private JsonSerializerSettings _jsonSerializerSettings;

        public PatreonClient(AccessTokenSettings accessTokenSettings)
        {
            _accessTokenSettings = accessTokenSettings;
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                Formatting = Formatting.Indented,
                Converters = new List<JsonConverter>()
                {
                    new ResponseObjectConverter()
                }
            };
        }

        public async Task<User> GetCurrentUser()
        {
            var json = await Get("oauth2/api/current_user");
            var response = JsonConvert.DeserializeObject<SimpleResponse>(json, _jsonSerializerSettings);
            return response.data as User;
        }

        public async Task<Campaign> GetCurrentCampaign()
        {
            var json = await Get("oauth2/api/current_user/campaigns?include=rewards,creator,goals,pledges");
            var response = JsonConvert.DeserializeObject<ComplexResponse>(json, _jsonSerializerSettings);
            return response.data.OfType<Campaign>().First();
        }

        public async Task<IEnumerable<Pledge>> GetAllPledges()
        {
            string json = await Get(@"oauth2/api/current_user/campaigns?include=pledges");
            var response = JsonConvert.DeserializeObject<ComplexResponse>(json, _jsonSerializerSettings);
            return response.included.OfType<Pledge>();
        }

        private async Task<string> Get(string endpoint)
        {
            HttpClient InnerClient = new HttpClient();
            InnerClient.BaseAddress = new Uri("https://api.patreon.com");
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            InnerClient.DefaultRequestHeaders.Add("Authorization",
                $"{_accessTokenSettings.TokenType} {_accessTokenSettings.AccessToken}");
            var response = await InnerClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}