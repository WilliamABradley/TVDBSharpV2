namespace TVDBSharp.Models
{
    public class TVDBArtwork
    {
        public string FileName { get; set; }
        public uint ID { get; set; }
        public string KeyType { get; set; }
        public uint? LanguageID { get; set; }
        public TVDBRatingInfo RatingsInfo { get; set; }
        public string Thumbnail { get; set; }
    }
}