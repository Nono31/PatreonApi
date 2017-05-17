using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Patreon.Core.Domain;

namespace Patreon.Core
{
    public class ResponseObjectConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObj = JObject.Load(reader);
            var type = jObj.Value<string>("type");

            if (type == "user")
            {
                return jObj.ToObject<User>();
            }
            if (type == "campaign")
            {
                return jObj.ToObject<Campaign>();
            }
            if (type == "pledge")
            {
                return jObj.ToObject<Pledge>();
            }
            if (type == "reward")
            {
                return jObj.ToObject<Reward>();
            }
            if (type == "goal")
            {
                return jObj.ToObject<Goal>();
            }
            if (type == "address")
            {
                return jObj.ToObject<Address>();
            }

            throw new NotSupportedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IResponseObject).IsAssignableFrom(objectType);
        }
    }
}
