using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Patreon.Core;
using Patreon.Core.Domain;

namespace Patreon.Api.Tests
{
    [TestClass]
    public class DeserializzationTest
    {
        [TestMethod]
        public void UserDeserializationTest()
        {
            string json = @"{
            ""data"": {
                ""attributes"": {
                    ""about"": """",
                    ""created"": ""2017-04-01T12:00:00+00:00"",
                    ""discord_id"": null,
                    ""email"": ""james@mymail.com"",
                    ""facebook"": null,
                    ""facebook_id"": null,
                    ""first_name"": ""Firstname"",
                    ""full_name"": ""Fullname"",
                    ""gender"": 0,
                    ""has_password"": true,
                    ""image_url"": ""https://c3.patreon.com/2/patreon-user/abc.jpg"",
                    ""is_deleted"": false,
                    ""is_email_verified"": true,
                    ""is_nuked"": false,
                    ""is_suspended"": false,
                    ""last_name"": """",
                    ""social_connections"": {
                        ""deviantart"": null,
                        ""discord"": null,
                        ""facebook"": null,
                        ""spotify"": null,
                        ""twitch"": null,
                        ""twitter"": null,
                        ""youtube"": null
                    },
                    ""thumb_url"": ""https://c3.patreon.com/2/patreon-user/abc.jpg"",
                    ""twitch"": null,
                    ""twitter"": null,
                    ""url"": ""https://www.patreon.com/user?u=123456"",
                    ""vanity"": null,
                    ""youtube"": null
                },
                ""id"": ""123456"",
                ""relationships"": {
                    ""pledges"": {
                        ""data"": []
                    }
                },
                ""type"": ""user""
            },
            ""links"": {
                ""self"": ""https://api.patreon.com/user/123456""
            }
            }";

            var response = JsonConvert.DeserializeObject<SimpleResponse>(json, new JsonSerializerSettings()
            {
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                Formatting = Formatting.Indented,
                Converters = new List<JsonConverter>() { new ResponseObjectConverter() }
            });
            Assert.AreEqual(123456, response.data.id);
            Assert.IsInstanceOfType(response.data, typeof(User));
            var user = response.data as User;
            Assert.AreEqual("james@mymail.com", user.email);
            Assert.AreEqual("Firstname", user.first_name);
            Assert.AreEqual("Fullname", user.full_name);
        }

        
    }
}