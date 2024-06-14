using Newtonsoft.Json;
using RandomUserApiPasc.Domain.Models.ValueObjects;

namespace RandomUserApiPasc.Domain.Models
{
    public class Results
    {
        [JsonProperty("results")]
        public Users[] Users { get; set; }
        public Info info { get; set; }
    }
}
