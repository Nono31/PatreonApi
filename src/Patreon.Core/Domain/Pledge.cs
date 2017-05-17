using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Patreon.Core.Domain
{
    public class Pledge : IResponseObject
    {
        public long id { get; set; }

        [JsonProperty("attributes")]
        public PledgeAttributes Attributes { get; set; }

    }

    public class PledgeAttributes
    {

        /// <summary>
        /// Amount of pledge in cents
        /// </summary>
        [JsonProperty("amount_cents")]
        public int Amount { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("declined_since")]
        public DateTime? DeclinedSince { get; set; }

        [JsonProperty("pledge_cap_cents")]
        public int pledge_cap_cents { get; set; }

        [JsonProperty("patron_pays_fees")]
        public bool patron_pays_fees { get; set; }

        [JsonProperty("unread_count")]
        public int unread_count { get; set; }
    }

    public class PledgeRelationships
    {
        [JsonProperty("patron")]
        public User Patreon { get; set; }

        [JsonProperty("reward")]
        public object Reward { get; set; }

        [JsonProperty("creator")]
        public User Creator { get; set; }

        [JsonProperty("address")]
        public object Address { get; set; }

        [JsonProperty("card")]
        public object Card { get; set; }

        [JsonProperty("pledge_vat_location")]
        public object PledgeVatLocation { get; set; }
    }
}
