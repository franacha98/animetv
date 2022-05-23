using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Api
{
    public class New
    {
        public int mal_id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public DateTime date { get; set; }
        public string author_username { get; set; }
        public string author_url { get; set; }
        public string forum_url { get; set; }
        public Images images { get; set; }
        public int comments { get; set; }
        public string excerpt { get; set; }
    }

    public class News
    {
        public Pagination pagination { get; set; }
        public List<New> data { get; set; }
    }


}
