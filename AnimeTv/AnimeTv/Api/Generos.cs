using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Api
{
    public class Genero
    {
        public int mal_id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int count { get; set; }
    }

    public class Raiz
    {
        public List<Genero> data { get; set; }
    }
}
