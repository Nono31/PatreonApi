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
    
    public class RelationshipCollection
    {
        public Relationship[] data { get; set; }
        public Links links { get; set; }
        public Meta meta { get; set; }
    }
    public class Relationship : IResponseObject
    {
        public long id { get; set; }
        public string type { get; set; }
    }
    public class Links 
    {
        public string first { get; set; }
        public string next { get; set; }
        public string related { get; set; }
    }
    public class Meta 
    {
        public int? count { get; set; }
    }
}
