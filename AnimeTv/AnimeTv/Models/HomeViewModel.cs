using AnimeTv.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Models
{
    public class HomeViewModel
    {
        public List<Episodios> EpisodiosRecientes;
        public List<Datum> AnimesEnEmision;
        public List<Datum> ProximosAnimes;
    }
}
