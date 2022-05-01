using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace AnimeTv.Api
{
    public class ApiWrapper
    {
        private string mUrlBase = $"https://api.jikan.moe/v4";

        public List<Datum> ObtenerAnimesPorNombre(string pNombre)
        {
            string peticion = $"{mUrlBase}/anime?letter={pNombre}";
            string response = UtilWeb.WebRequest("GET", peticion, null);
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response, settings);

            List<Datum> lista = myDeserializedClass.data;

            return lista;
        }

        public List<Datum> ObtenerAnimesPorNombre(string pNombre, int pPagina, int pLimite)
        {
            string peticion = $"{mUrlBase}/anime?letter={pNombre}&page={pPagina}&limit={pLimite}";
            string response = UtilWeb.WebRequest("GET", peticion, null);
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response, settings);

            List<Datum> lista = myDeserializedClass.data;

            return lista;
        }

        public List<Genero> ObtenerListadoGeneros()
        {
            string peticion = $"{mUrlBase}/genres/anime";
            string response = UtilWeb.WebRequest("GET", peticion, null);
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            Raiz myDeserializedClass = JsonConvert.DeserializeObject<Raiz>(response, settings);

            List<Genero> lista = myDeserializedClass.data;

            return lista;
        }
    }
}
