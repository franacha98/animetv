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

        public Data ObtenerAnimePorID(int pAnimeId)
        {
            string peticion = $"{mUrlBase}/anime/{pAnimeId}";
            string response = UtilWeb.WebRequest("GET", peticion, null);
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            AnimeData myDeserializedClass = JsonConvert.DeserializeObject<AnimeData>(response, settings);
            Data anime = myDeserializedClass.data;

            return anime;
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

        public Pagination ObtenerInfoPaginacion(int pLimite)
        {
            string peticion = $"{mUrlBase}/anime?letter=&limit={pLimite}";
            string response = UtilWeb.WebRequest("GET", peticion, null);
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response, settings);

            Pagination info = myDeserializedClass.pagination;

            return info;
        }

        public List<Datum> ObtenerAnimesFiltrados(int pGenero, int pPagina, string pOrden, string pEstado)
        {
            if (pOrden == "asc")
            {
                pOrden = "title&sort=asc";
            }
            else if (pOrden == "desc")
            {
                pOrden = "title&sort=desc";
            }
            string peticion = $"{mUrlBase}/anime?letter=&page={pPagina}&limit=20&order_by={pOrden}&status={pEstado}&genres={pGenero}";
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

        public List<Datum> ObtenerAnimesEnEmision()
        {
            string peticion = $"{mUrlBase}/top/anime?filter=airing";
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

        public List<Datum> ObtenerProximosEstrenos()
        {
            string peticion = $"{mUrlBase}/top/anime?filter=upcoming";
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
        public List<Episodios> ObtenerUltimosEpisodios()
        {
            string peticion = $"{mUrlBase}/watch/episodes";
            string response = UtilWeb.WebRequest("GET", peticion, null);
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            RootEpisodios myDeserializedClass = JsonConvert.DeserializeObject<RootEpisodios>(response, settings);
            List<Episodios> lista = myDeserializedClass.data;

            return lista;
        }
    }
}
