using AnimeTv.Api;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Models
{
    public class DirectorioAnimeViewModel
    {
        public List<Datum> ListaAnimes { get; set; }
        public List<Genero> Generos { get; set; }
        public int Pagina { get; set; }
        public string Filtro { get; set; }
        public string EstadoSeleccionado { get; set; }
        public string OrdenSeleccionado { get; set; }
        public int GeneroSeleccionado { get; set; }
        public Pagination InfoPaginas { get; set; }
    }
}
