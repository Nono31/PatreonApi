using System;
using System.Collections.Generic;
using System.Text;

namespace Patreon.Core.Domain
{
    public class Goal : IResponseObject
    {
        public long id { get; set; }

        public object relationships { get; set; }
        internal GoalAttributes attributes { get; set; }

        internal class GoalAttributes
        {
            /// <summary>
            /// Gets or sets the amount of cash required to reach this goal, in cents.
            /// </summary>
            public int amount_cents { get; set; }

            /// <summary>
            /// Gets or sets the percentage of completion.
            /// </summary>
            public int completed_percentage { get; set; }

            /// <summary>
            /// Gets or sets the time at which this goal was created.
            /// </summary>
            public DateTime created_at { get; set; }

            /// <summary>
            /// Gets or sets this goal's description.
            /// </summary>
            public string description { get; set; }

            /// <summary>
            /// Gets or sets the time at which this goal was reached.
            /// </summary>
            /// <remarks>Not all goals have been reached yet - if that's the case for this goal, this property will start off as null.</remarks>
            public DateTime reached_at { get; set; }

            /// <summary>
            /// Gets or sets this goal's title.
            /// </summary>
            public string title { get; set; }
        }
    }

    
}
