using Newtonsoft.Json;

namespace Plataformas
{
    public class GOGAPI
    {
        [JsonProperty("images")]
        public GOGAPIImagenes imagenes { get; set; }
    }

    public class GOGAPIImagenes
    {
        [JsonProperty("logo")]
        public string logo { get; set; }
    }
}
