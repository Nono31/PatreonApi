using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Patreon.Core.Domain
{
    public class Response
    {
        [JsonProperty("data")]
        public object Data { get; set; }
    }

    public class ResponseData
    {
        public ResponseType type { get; set; }
        public long id { get; set; }
    }
    
}
