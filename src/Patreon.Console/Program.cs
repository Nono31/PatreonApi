using System;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http;
using Patreon.Api;
using Patreon.Core;

namespace Patreon
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Press any key to start...");
            //Console.ReadKey();

            Program p = new Program();
            p.Start();

            Console.ReadKey();
        }

        public async void Start()
        {
            Settings settings = new Settings(string.Empty);
            settings.Load();
            if (string.IsNullOrWhiteSpace(settings.AccessTokenSettings?.TokenType))
            {
                OAuth oAuth = new OAuth();
                string redirectURI = settings.ApiSettings.RedirectUrl;
                var code = await oAuth.Authorize(settings.ApiSettings.ClientId, redirectURI);
                var token = await oAuth.PerformCodeExchange(settings.ApiSettings.ClientId,
                    settings.ApiSettings.ClientSecret, code, redirectURI);
                settings.AccessTokenSettings = new AccessTokenSettings(token);
                settings.Save();
            }
            else
            {

                OAuth oAuth = new OAuth();
                var token = await oAuth.RefreshToken(settings.ApiSettings.ClientId,
                    settings.ApiSettings.ClientSecret, settings.AccessTokenSettings.RefreshToken);
                settings.AccessTokenSettings = new AccessTokenSettings(token);
                settings.Save();
            }

            PatreonClient client = new PatreonClient(settings.AccessTokenSettings);
            var user = await client.GetCurrentUser();
            Console.WriteLine($"UserData {user.email} logged in");

            var campaign = await client.GetCurrentCampaign();
            Console.WriteLine($"Campagn id {campaign.id} ");
            Console.WriteLine($"you have {campaign.PatronCount} patren(s)");
            Console.WriteLine($"for a total of {campaign.PledgeSum} cents");
            var pledges = await client.GetAllPledges();

            foreach (var pledge in pledges)
            {
                Console.WriteLine($"{pledge.Amount}");
            }
        }
    }
}