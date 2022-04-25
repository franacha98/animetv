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
            string peticion = $"{mUrlBase}/anime?q={pNombre}&sfw";
            string response = UtilWeb.WebRequest("GET", peticion, null);
            //dynamic json = JsonConvert.DeserializeObject(response);
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(response, settings);

            List<Datum> lista = myDeserializedClass.data;

            return lista;
        }
    }
}
