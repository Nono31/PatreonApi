using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Patreon.Core.Domain
{
    public class ComplexResponse
    {
        public List<IResponseObject> data { get; set; }
        public List<IResponseObject> included { get; set; }
    }
    
    public class SimpleResponse
    {
        public IResponseObject data  { get; set; }
        public IResponseObject included { get; set; }
    }
    
    
    public interface IResponseObject
    {
         long id { get; set; }
    }

    public class PledgeData : IResponseObject
    {
        [JsonProperty("attributes")]
        public Pledge attributes { get; set; }
        public PledgeRelationships relationships { get; set; }
        public long id { get; set; }
    }
    
    
    public class IncludedDataCollection
    {
        public object[] included { get; set; }
    }

    public class DataCollection
    {
        public IResponseObject[] data { get; set; }
    }
}
