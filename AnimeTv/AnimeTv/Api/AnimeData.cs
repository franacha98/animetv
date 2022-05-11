using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Api
{
    

    public class Data
    {
        public int mal_id { get; set; }
        public string url { get; set; }
        public Images images { get; set; }
        public Trailer trailer { get; set; }
        public string title { get; set; }
        public string title_english { get; set; }
        public string title_japanese { get; set; }
        public List<string> title_synonyms { get; set; }
        public string type { get; set; }
        public string source { get; set; }
        public int episodes { get; set; }
        public string status { get; set; }
        public bool airing { get; set; }
        public Aired aired { get; set; }
        public string duration { get; set; }
        public string rating { get; set; }
        public double score { get; set; }
        public int scored_by { get; set; }
        public int rank { get; set; }
        public int popularity { get; set; }
        public int members { get; set; }
        public int favorites { get; set; }
        public string synopsis { get; set; }
        public object background { get; set; }
        public object season { get; set; }
        public object year { get; set; }
        public Broadcast broadcast { get; set; }
        public List<Producer> producers { get; set; }
        public List<Licensor> licensors { get; set; }
        public List<Studio> studios { get; set; }
        public List<Genre> genres { get; set; }
        public List<object> explicit_genres { get; set; }
        public List<object> themes { get; set; }
        public List<Demographic> demographics { get; set; }
    }

    public class Demographic
    {
        public int mal_id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    

    public class Licensor
    {
        public int mal_id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }


    public class AnimeData
    {
        public Data data { get; set; }
    }    
}
