using Newtonsoft.Json;

namespace MoveIT.Web.Models
{
    public class Price
    {
        [JsonProperty("distance")]
        public int Distance { get; set; }
        [JsonProperty("livingSpace")]
        public int LivingSpace { get; set; }
        [JsonProperty("storageSpace")]
        public int StorageSpace { get; set; }
        [JsonProperty("hasHeavyItem")]
        public bool HasHeavyItem    { get; set; }
    }
}
