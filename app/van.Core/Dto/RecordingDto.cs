using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace van.Core.Dto
{
    public class RecordingDto
    {
        public int Id { get; set; }

        [JsonProperty]
        public string Title { get; set; }
        
        [JsonProperty]
        public string Speaker { get; set; }
        
        [JsonProperty]
        public string UserGroup { get; set; }
        
        [JsonProperty]
        public string Date { get; set; }
        
        [JsonProperty]
        public virtual string Duration { get; set; }
    }
}