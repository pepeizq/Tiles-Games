using Newtonsoft.Json;
using System.Collections.Generic;

namespace Plataformas
{
    public class EAPlayAPI
    {
        [JsonProperty("offers")]
        public List<EAPlayAPIJuego> juegos { get; set; }
    }

    public class EAPlayAPIJuego
    {
        [JsonProperty("contentId")]
        public string idWeb { get; set; }

        [JsonProperty("i18n")]
        public EAPlayAPIJuegoImagenes i18n { get; set; }

        [JsonProperty("imageServer")]
        public string imagenRaiz { get; set; }
    }

    public class EAPlayAPIJuegoImagenes
    {
        [JsonProperty("packArtLarge")]
        public string imagenGrande { get; set; }
    }
}