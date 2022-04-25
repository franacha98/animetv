using AnimeTv.Api;
using AnimeTv.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Models
{
    public class BorrarVideoModel
    {
        public List<Video> ListaVideos { get; set; }
        public List<Datum> ListaAnimes { get; set; }
    }
}
