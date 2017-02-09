using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastBillNet.Converter
{
    public class DateConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value;        
           
            if ("0000-00-00".Equals(value))
            {
                return null;
            }

            return DateTime.Parse(value.ToString());            
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(String))
            {
                return true;
            }
            return false;
        }
    }

}
