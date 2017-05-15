using System;
using Newtonsoft.Json;

namespace Patreon.Core.Domain
{
    public class User : ResponseData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public ResponseType Type { get; set; }

        [JsonProperty("attributes")]
        public UserAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public UserRelationships Relationships { get; set; }
    }

    public class UserAttributes
    {
        [JsonProperty("about")]
        public string about { get; set; }

        [JsonProperty("created")]
        public DateTime created { get; set; }

        [JsonProperty("discord_id")]
        public string discord_id { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("facebook")]
        public string facebook { get; set; }

        [JsonProperty("facebook_id")]
        public string facebook_id { get; set; }

        [JsonProperty("first_name")]
        public string first_name { get; set; }

        [JsonProperty("full_name")]
        public string full_name { get; set; }

        [JsonProperty("gender")]
        public int gender { get; set; }

        [JsonProperty("last_name")]
        public string last_name { get; set; }

        [JsonProperty("vanity")]
        public string vanity { get; set; }

        [JsonProperty("image_url")]
        public string image_url { get; set; }

        [JsonProperty("thumb_url")]
        public string thumb_url { get; set; }

        [JsonProperty("youtube")]
        public string youtube { get; set; }

        [JsonProperty("twitter")]
        public string twitter { get; set; }

        [JsonProperty("is_deleted")]
        public bool is_deleted { get; set; }

        [JsonProperty("is_email_verified")]
        public bool is_email_verified { get; set; }

        [JsonProperty("is_suspended")]
        public bool is_suspended { get; set; }

        [JsonProperty("is_nuked")]
        public bool is_nuked { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("has_password")]
        public bool has_password { get; set; }

        [JsonProperty("twitch")]
        public string twitch { get; set; }

        [JsonProperty("social_connections")]
        public SocialConnections SocialConnections { get; set; }
    }

    public class UserRelationships
    {
        //[JsonProperty("campaign")]
        //public Campaign Campaign { get; set; }

        //[JsonProperty("pledges")]
        //public Pledge Pledges { get; set; }
    }


    public class SocialConnections
    {
        public string devianart { get; set; }
        public string disocrd { get; set; }
        public string facebook { get; set; }
        public string spotify { get; set; }
        public string twitch { get; set; }
        public string twitter { get; set; }
        public string youtube { get; set; }
    }
}