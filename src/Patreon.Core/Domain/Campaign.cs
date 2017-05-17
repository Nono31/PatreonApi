using System;
using System.Collections.Generic;
using System.Text;

namespace Patreon.Core.Domain
{
    public class Campaign : IResponseObject
    {
        public CampaignAttributes attributes { get; set; }
        //TODO
        //public CampaignRelationships relationships { get; set; }
        public long id { get; set; }
    }

    public class CampaignRelationships
    {
        /*
         * "creator": ...<user>...,
            "rewards": [ ...<reward>, <reward>, ... ],
            "goals": [ ...<goal>, <goal>, ... ],
            "pledges": [ ...<pledge>, <pledge>, ... ],
         */

        public User creator { get; set; }
        public DataCollection rewards { get; set; }
        public DataCollection goals { get; set; }
        public DataCollection pledges { get; set; }
    }

    public class CampaignAttributes
    {
        /// <summary>
        /// Gets or sets the name of the creation.
        /// </summary>
        public string creation_name { get; set; }

        /// <summary>
        /// Gets or sets when this campaign was created.
        /// </summary>
        public DateTime created_at { get; set; }

        /// <summary>
        /// Gets or sets the amount of creations.
        /// </summary>
        public int creation_count { get; set; }

        /// <summary>
        /// Getes or sets the Discord server ID for Discord integration.
        /// </summary>
        public long? discord_server_id { get; set; }

        /// <summary>
        /// Gets or sets whether or not patron goals should be shown publicly.
        /// </summary>
        public bool display_patron_goals { get; set; }

        /// <summary>
        /// Not yet known.
        /// </summary>
        public object earnings_visibilty { get; set; }

        /// <summary>
        /// The URL for the banner image.
        /// </summary>
        public string image_url { get; set; }

        /// <summary>
        /// The URL for the small version of the banner image.
        /// </summary>
        public string image_small_url { get; set; }

        /// <summary>
        /// Are patrons charged immediately?
        /// </summary>
        public bool is_charged_immediately { get; set; }

        /// <summary>
        /// Are Patrons charged monthly?
        /// </summary>
        public bool is_monthly { get; set; }

        /// <summary>
        /// Is this page adults-only?
        /// </summary>
        public bool is_nsfw { get; set; }

        /// <summary>
        /// Is the creator creating the project, or are the creators creating the project?
        /// </summary>
        public bool is_plural { get; set; }

        /// <summary>
        /// Gets or sets the embed code for the main video.
        /// </summary>
        public string main_video_embed { get; set; }

        /// <summary>
        /// Gets or sets the URL of the main video.
        /// </summary>
        public string main_video_url { get; set; }

        /// <summary>
        /// Gets or sets the one-liner text.
        /// </summary>
        public string one_liner { get; set; }

        /// <summary>
        /// Gets the outstanding payment amount in cents.
        /// </summary>
        public long outstanding_payment_amount_cents { get; set; }

        /// <summary>
        /// Gets or sets the amount of patrons in this campaign.
        /// </summary>
        public int patron_count { get; set; }

        /// <summary>
        /// Gets or sets the pay-per name.
        /// </summary>
        public string pay_per_name { get; set; }

        /// <summary>
        /// Gets or sets the pledge sum.
        /// </summary>
        public int pledge_sum { get; set; }

        /// <summary>
        /// Gets or sets the pledge URL.
        /// </summary>
        public string pledge_url { get; set; }

        /// <summary>
        /// Gets or sets the date and time this campaign went live.
        /// </summary>
        public DateTime published_at { get; set; }

        /// <summary>
        /// Gets or sets the campaign summary.
        /// </summary>
        public string summary { get; set; }

        /// <summary>
        /// Gets or sets the "thank you" video embed.
        /// </summary>
        public string thanks_embed { get; set; }

        /// <summary>
        /// Gets or sets the "thank you" message.
        /// </summary>
        public string thanks_msg { get; set; }

        /// <summary>
        /// Gets or sets the "thank you" video URL.
        /// </summary>
        public string thanks_video_url { get; set; }



    }

}
