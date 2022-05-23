using AnimeTv.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Models
{
    public class FichaViewModel
    {
        public Data AnimeData;
        public int Id;
        public string Nombre;
        public string Productora;
        public int Capitulos;
        public string Estudio;
        public bool Emision;
        public List<Demographic> Generos;
        public List<EpisodioAnime> Episodios;
        public int Count;
    }
}
