using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Patreon.Core.Domain
{
    public class Address : IResponseObject
    {
        public long id { get; set; }
        [JsonProperty("attributes")]
        internal AddressAttributes Attributes { get; set; }

        #region Flattern
        public string Addressee { get => Attributes.Addressee; set => Attributes.Addressee = value; }
        public string City { get => Attributes.City; set => Attributes.City = value; }
        public string Country { get => Attributes.Country; set => Attributes.Country = value; }
        public string Line1 { get => Attributes.Line1; set => Attributes.Line1 = value; }
        public string Line2 { get => Attributes.Line2; set => Attributes.Line2 = value; }
        public string PostalCode { get => Attributes.PostalCode; set => Attributes.PostalCode = value; }
        public string State { get => Attributes.State; set => Attributes.State = value; }
        #endregion

        internal class AddressAttributes
        {
            [JsonProperty("addressee")]
            public string Addressee { get; set; }
            [JsonProperty("city")]
            public string City { get; set; }
            [JsonProperty("country")]
            public string Country { get; set; }
            [JsonProperty("line_1")]
            public string Line1 { get; set; }
            [JsonProperty("line_2")]
            public string Line2 { get; set; }
            [JsonProperty("postal_code")]
            public string PostalCode { get; set; }
            [JsonProperty("state")]
            public string State { get; set; }
        }
    }

    
}
