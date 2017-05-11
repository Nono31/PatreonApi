using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Patreon.Api.Domain;

namespace Patreon.Api
{
    public class OAuth
    {
        const string authorizationEndpoint = "https://www.patreon.com/oauth2/authorize";

        public async Task<string> Authorize(string clientId, string redirectURI)
        {
            string state = GenerateState();
            var authorizationRequest =
                $"{authorizationEndpoint}?response_type=code&client_id={clientId}&redirect_uri={redirectURI}&state={state}";

            // Creates an HttpListener to listen for requests on that redirect URI.
            var http = new HttpListener(IPAddress.Loopback, new Uri(redirectURI).Port);
            http.Start();


            // Opens request in the browser.
            OpenBrowser(authorizationRequest);


            // Waits for the OAuth authorization response.
            var context = await http.GetContextAsync();

            // Sends an HTTP response to the browser.
            var response = context.Response;

            string responseString = "<html><head><meta http-equiv=\'refresh\'></head><body>Success</body></html>";

            await response.WriteContentAsync(responseString).ContinueWith((task) =>
             {
                 response.Close();
                 http.Close();
                 Console.WriteLine("HTTP server stopped.");
             });
            
            var queryString = context.Request.RequestUri.Query;
            var queryDictionary = HttpUtility.ParseQueryString(queryString);

            // Checks for errors.
            if (queryDictionary.GetValues("error").FirstOrDefault() != null)
            {
                return string.Empty;
            }
            if (queryDictionary.GetValues("code").FirstOrDefault() == null)
            {
                return string.Empty;
            }

            // extracts the code
            return queryDictionary.GetValues("code").FirstOrDefault();
        }

        public async Task<AccessTokenReponse> PerformCodeExchange(string clientId, string clientSecret, string code,
            string redirectURI)
        {
            try
            {
                HttpClient InnerClient = new HttpClient();
                InnerClient.BaseAddress = new Uri("https://api.patreon.com");
                var request = new HttpRequestMessage(HttpMethod.Post, "oauth2/token");
                request.Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret),
                    new KeyValuePair<string, string>("redirect_uri", redirectURI)
                });
                var response = await InnerClient.SendAsync(request);
                var token = JsonConvert.DeserializeObject<AccessTokenReponse>(response.Content.ReadAsStringAsync().Result);
                return token;
            }
            catch (Exception ex)
            {
                //TODO log
                throw;
            }
        }
        
        private static string GenerateState()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

    }
}
