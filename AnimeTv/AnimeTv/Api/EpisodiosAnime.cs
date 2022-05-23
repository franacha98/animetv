using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Api
{


    public class EpisodioAnime
    {
        public int mal_id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string title_japanese { get; set; }
        public string title_romanji { get; set; }
        public DateTime aired { get; set; }
        public bool filler { get; set; }
        public bool recap { get; set; }
        public string forum_url { get; set; }
    }

    public class RootEpisodioAnime
    {
        public Pagination pagination { get; set; }
        public List<EpisodioAnime> data { get; set; }
    }

}
