using System;
using Newtonsoft.Json;

namespace Patreon.Core.Domain
{
    public class User : IResponseObject
    {
        [JsonProperty("id")]
        public long id { get; set; }

        //[JsonProperty("type")]
        //public ResponseType type { get; set; }

        [JsonProperty("attributes")]
        public UserAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public UserRelationships Relationships { get; set; }

        #region Flattern
        [JsonIgnore]
        public string about { get => Attributes.about; set => Attributes.about = value; }

        [JsonIgnore]
        public DateTime created { get => Attributes.created; set => Attributes.created = value; }

        [JsonIgnore]
        public string discord_id { get => Attributes.discord_id; set => Attributes.discord_id = value; }

        [JsonIgnore]
        public string email { get => Attributes.email; set => Attributes.email = value; }

        [JsonIgnore]
        public string facebook { get => Attributes.facebook; set => Attributes.facebook = value; }

        [JsonIgnore]
        public string facebook_id { get => Attributes.facebook_id; set => Attributes.facebook_id = value; }

        [JsonIgnore]
        public string first_name { get => Attributes.first_name; set => Attributes.first_name = value; }

        [JsonIgnore]
        public string full_name { get => Attributes.full_name; set => Attributes.full_name = value; }

        [JsonIgnore]
        public int gender { get => Attributes.gender; set => Attributes.gender = value; }

        [JsonIgnore]
        public string last_name { get => Attributes.last_name; set => Attributes.last_name = value; }

        [JsonIgnore]
        public string vanity { get => Attributes.vanity; set => Attributes.vanity = value; }

        [JsonIgnore]
        public string image_url { get => Attributes.image_url; set => Attributes.image_url = value; }

        [JsonIgnore]
        public string thumb_url { get => Attributes.thumb_url; set => Attributes.thumb_url = value; }

        [JsonIgnore]
        public string youtube { get => Attributes.youtube; set => Attributes.youtube = value; }

        [JsonIgnore]
        public string twitter { get => Attributes.twitter; set => Attributes.twitter = value; }

        [JsonIgnore]
        public bool is_deleted { get => Attributes.is_deleted; set => Attributes.is_deleted = value; }

        [JsonIgnore]
        public bool is_email_verified { get => Attributes.is_email_verified; set => Attributes.is_email_verified = value; }

        [JsonIgnore]
        public bool is_suspended { get => Attributes.is_suspended; set => Attributes.is_suspended = value; }

        [JsonIgnore]
        public bool is_nuked { get => Attributes.is_nuked; set => Attributes.is_nuked = value; }

        [JsonIgnore]
        public string url { get => Attributes.url; set => Attributes.url = value; }

        [JsonIgnore]
        public bool has_password { get => Attributes.has_password; set => Attributes.has_password = value; }

        [JsonIgnore]
        public string twitch { get => Attributes.twitch; set => Attributes.twitch = value; }

        [JsonIgnore]
        public SocialConnections SocialConnections { get => Attributes.SocialConnections; set => Attributes.SocialConnections = value; }
        #endregion
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
        [JsonProperty("campaign")]
        public Campaign Campaign { get; set; }

        [JsonProperty("pledges")]
        public Pledge Pledges { get; set; }
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