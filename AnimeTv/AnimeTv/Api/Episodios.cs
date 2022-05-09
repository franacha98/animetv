using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Api
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Episodios
    {
        public Entry entry { get; set; }
        public List<Episode> episodes { get; set; }
        public bool region_locked { get; set; }
    }

    public class Entry
    {
        public int mal_id { get; set; }
        public string url { get; set; }
        public Images images { get; set; }
        public string title { get; set; }
    }

    public class Episode
    {
        public int mal_id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public bool premium { get; set; }
    }

    public class Imagenes
    {
        public Jpg jpg { get; set; }
        public Webp webp { get; set; }
    }

    public class Jpgs
    {
        public string image_url { get; set; }
        public string small_image_url { get; set; }
        public string large_image_url { get; set; }
    }

    public class Paginacion
    {
        public int last_visible_page { get; set; }
        public bool has_next_page { get; set; }
    }

    public class RootEpisodios
    {
        public Pagination pagination { get; set; }
        public List<Episodios> data { get; set; }
    }

    public class Webps
    {
        public string image_url { get; set; }
        public string small_image_url { get; set; }
        public string large_image_url { get; set; }
    }


}
