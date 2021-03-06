﻿namespace TolokaSearcher.Toloka
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

        public override string ToString()
        {
            return
                $"ID: {id}" +
                $"\nLink: {link}" +
                $"\nTitle: {title}" +
                $"\nForum name: {title}" +
                $"\nForum parent: {forum_parent}" +
                $"\nComments: {comments}" +
                $"\nSize: {size}" +
                $"\nSeeders: {seeders}" +
                $"\nLeechers: {leechers}" +
                $"\nComplete: {complete}";
        }
    }
}
