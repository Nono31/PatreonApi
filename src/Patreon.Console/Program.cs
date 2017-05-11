using System;
using System.Net.Http;
using Patreon.Api;

namespace Patreon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            Program p = new Program();
            p.Start();

            Console.ReadKey();
        }

        // client configuration
        const string clientID = "";
        const string clientSecret = "";

        public async void Start()
        {
            OAuth oAuth = new OAuth();
            string redirectURI = "http://127.0.0.1:60135/";
            var code = await oAuth.Authorize(clientID, redirectURI);
            var token = await oAuth.PerformCodeExchange(clientID, clientSecret, code, redirectURI);
            HttpClient InnerClient = new HttpClient();
            InnerClient.BaseAddress = new Uri("https://api.patreon.com");
            var request = new HttpRequestMessage(HttpMethod.Get, "oauth2/api/current_user");
            InnerClient.BaseAddress = new Uri("https://api.patreon.com");
            InnerClient.DefaultRequestHeaders.Add("Authorization", $"{token.TokenType} {token.AccessToken}");
            var response = await InnerClient.SendAsync(request);
            var result = response.Content.ReadAsStringAsync().Result;
        }
    }
}