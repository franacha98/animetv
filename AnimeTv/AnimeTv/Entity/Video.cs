using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Entity
{
    [Serializable]
    public class Video
    {
        public Video(int pVideoID, int pAnime, int pTemporada, int pCapitulo)
        {
            VideoId = pVideoID;
            Anime = pAnime;
            Temporada = pTemporada;
            Capitulo = pCapitulo;
        }

        public int VideoId { get; set; }
        public int Anime { get; set; }
        public int Temporada { get; set; }
        public int Capitulo { get; set; }
    }
}
