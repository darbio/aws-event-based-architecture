using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public abstract class Event
    {
        public string Serialize()
        {
            return Event.Serialize(this);
        }

        public static string Serialize<T>(T @object)
        {
            return JsonConvert.SerializeObject(@object);
        }

        public static T Deserialize<T>(string value) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
