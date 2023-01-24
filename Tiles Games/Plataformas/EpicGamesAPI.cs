using Newtonsoft.Json;
using System.Collections.Generic;

namespace Plataformas
{
    public class EpicGamesAPI
    {
        [JsonProperty("titulo")]
        public string nombre { get; set; }

        [JsonProperty("id_steam")]
        public string idSteam { get; set; }

        [JsonProperty("ids_epic")]
        public List<string> idsEpic { get; set; }

        [JsonProperty("imagen_pequeña")]
        public string imagenPequeña { get; set; }

        [JsonProperty("imagen_grande")]
        public string imagenGrande { get; set; }
    }
}