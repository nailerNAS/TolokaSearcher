using Newtonsoft.Json;
using System.Collections.Generic;

namespace TolokaSearcher.Toloka
{
    public class TolokaResult
    {
        public string id { get; set; }
        public string link { get; set; }
        public string title { get; set; }
        public string forum_name { get; set; }
        public string forum_parent { get; set; }
        public string comments { get; set; }
        public string size { get; set; }
        public string seeders { get; set; }
        public string leechers { get; set; }
        public string complete { get; set; }

        public static TolokaResult fromJson(Dictionary<string, string> json)
        {
            string stringJson = JsonConvert.SerializeObject(json);
            return (TolokaResult)JsonConvert.DeserializeObject(stringJson);
        }
    }
}
