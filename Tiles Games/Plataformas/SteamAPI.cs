using Newtonsoft.Json;

namespace Plataformas
{
    public class SteamAPI
    {
        [JsonProperty("data")]
        public SteamAPIDatos datos { get; set; }
    }

    public class SteamAPIDatos
    {
        [JsonProperty("name")]
        public string titulo { get; set; }
    }
}
