using Flurl;
using Flurl.Http;
using System.Collections.Generic;

namespace TolokaSearcher.Toloka
{
    public class Searcher
    {
        private static string apiUrl = "https://toloka.to/api.php";

        public List<TolokaResult> search (string query)
        {
            return apiUrl
                .SetQueryParam("search", query)
                .GetAsync()
                .ReceiveJson<List<TolokaResult>>()
                .Result;
        }
    }
}
