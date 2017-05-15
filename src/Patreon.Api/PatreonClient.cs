using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Patreon.Core;
using Patreon.Core.Domain;

namespace Patreon.Api
{
    public class PatreonClient
    {
        private AccessTokenSettings _accessTokenSettings;

        public PatreonClient(AccessTokenSettings accessTokenSettings)
        {
            _accessTokenSettings = accessTokenSettings;
        }

        public async Task<User> GetCurrentUser()
        {
            var json = await Get("oauth2/api/current_user");
            var response = JsonConvert.DeserializeObject<Response>(json);
            var c = JsonConvert.SerializeObject(response.Data);
            return JsonConvert.DeserializeObject<User>(c);
        }
        

        private async Task<string> Get(string endpoint)
        {
            HttpClient InnerClient = new HttpClient();
            InnerClient.BaseAddress = new Uri("https://api.patreon.com");
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            InnerClient.DefaultRequestHeaders.Add("Authorization", $"{_accessTokenSettings.TokenType} {_accessTokenSettings.AccessToken}");
            var response =  await InnerClient.SendAsync(request);
            var test = await response.Content.ReadAsStringAsync();
            return test;
        }
    }
}