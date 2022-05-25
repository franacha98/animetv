using AnimeTv.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Models
{
    public class ListaViewModel
    {
        public string NombreUsuario { get; set; }
        public List<Data> ListaAnimes { get; set; }
    }
}
