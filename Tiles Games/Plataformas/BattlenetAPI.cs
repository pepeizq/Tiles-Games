using Newtonsoft.Json;

namespace Plataformas
{
    public class BattlenetAPI
    {
        [JsonProperty("titulo")]
        public string nombre { get; set; }

        [JsonProperty("id_steam")]
        public string idSteam { get; set; }

        [JsonProperty("id_battlenet")]
        public string idBattlenet { get; set; }

        [JsonProperty("imagen_pequeña")]
        public string imagenPequeña { get; set; }

        [JsonProperty("imagen_grande")]
        public string imagenGrande { get; set; }
    }
}