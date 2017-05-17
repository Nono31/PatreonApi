using System;
using System.Collections.Generic;
using System.Text;

namespace Patreon.Core.Domain
{
    public class Address : IResponseObject
    {
        public long id { get; set; }
        public AddressAttributes attributes { get; set; }
    }

    public class AddressAttributes
    {
        public string addressee { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string line_1 { get; set; }
        public string line_2 { get; set; }
        public string postal_code { get; set; }
        public string state { get; set; }
    }
}
