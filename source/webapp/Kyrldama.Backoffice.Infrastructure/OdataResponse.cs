using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Kyrldama.Backoffice.Infrastructure
{
    public class OdataResponse<T>
    {
        [JsonPropertyName("@odata.context")]
        public string Context { get; set; }

        [JsonPropertyName("value")]
        public T Value { get; set; }
    }

    public class EnumerableOdataResponse<T> where T : class
    {
        [JsonProperty("@odata.context")]
        public string Context { get; set; }

        [JsonProperty("@odata.count")]
        public int Count { get; set; }

        [JsonProperty("value")]
        public IEnumerable<T> Value { get; set; }
    }
}
