using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignUpApplication.Helper
{
    /*{
    "_id": {
        "$oid": "5875a5d4f36d285ed998f35e"
    },
    "name": "Ali Al-Bahrani",
    "age": 33,
    "sickness": "Headech",
    "allergies": "None"
}
*/
    public class Id
    {
        [JsonProperty(PropertyName = "$oid")]
        public string oid { get; set; }
    }

    public class Patient
    {
        public Id _id { get; set; }
        public string name { get; set; }
        public string age { get; set; }
        public string sickness { get; set; }
        public string allergies { get; set; }
    }
}
