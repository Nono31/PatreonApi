using System;
using System.Collections.Generic;
using System.Text;

namespace Patreon.Core.Domain
{
    public class Reward : IResponseObject
    {
        public long id { get; set; }
        public RewardAttributes attributes { get; set; }
        //TODO relationships creator
    }

    public class RewardAttributes
    {
        public int amount { get; set; }
        public int amount_cents { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? deleted_at { get; set; }
        public DateTime? edited_at { get; set; }
        public string image_url { get; set; }
        public bool? is_twitch_reward { get; set; }
        public int? patron_count { get; set; }
        public int? post_count { get; set; }
        public bool? published { get; set; }
        public DateTime? published_at { get; set; }
        public string description { get; set; }
        public int? remaining { get; set; }
        public bool requires_shipping { get; set; }
        public string title { get; set; }
        public DateTime? unpublished_at { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string user_limit { get; set; }
    }
}
