using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API.DTO
{
    public class FeedDto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("desc")]
        public string Description { get; set; }
        
        [JsonPropertyName("img")]
        public string Image { get; set; }
        
        [JsonPropertyName("entries")]
        public List<FeedEntryDto> Entries { get; set; }
    }
}
