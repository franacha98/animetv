using AnimeTv.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Models
{
    public class PlayerViewModel
    {
        public string UrlVideo;
        public int VideoID;
        public string EmbedFrame;
        public string Anime;
        public int Capitulo;
        public Data AnimeData;
        public List<New> Noticias;
        public bool Visto;
    }
}
