using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.DTO
{
    public class FeedEntryDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("link")]
        public string Link { get; set; }
        
        [JsonPropertyName("pubDate")]
        public string PublishDate { get; set; }
        
        [JsonPropertyName("authors")]
        public List<string> Authors { get; set; }
    }
}
