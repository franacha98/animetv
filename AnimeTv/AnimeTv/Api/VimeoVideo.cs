using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Api
{
    public class VimeoVideo
    {
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Albums
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class App
    {
        public string name { get; set; }
        public string uri { get; set; }
    }

    public class Appearances
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class Badges
    {
        public bool hdr { get; set; }
        public Live live { get; set; }
        public StaffPick staff_pick { get; set; }
        public bool vod { get; set; }
        public bool weekend_challenge { get; set; }
    }

    public class Capabilities
    {
        public bool hasLiveSubscription { get; set; }
        public bool hasEnterpriseLihp { get; set; }
        public bool hasSvvTimecodedComments { get; set; }
    }

    public class Channels
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class Comments
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class Connections
    {
        public Comments comments { get; set; }
        public Credits credits { get; set; }
        public Likes likes { get; set; }
        public Pictures pictures { get; set; }
        public Texttracks texttracks { get; set; }
        public object related { get; set; }
        public Recommendations recommendations { get; set; }
        public Albums albums { get; set; }
        public Appearances appearances { get; set; }
        public Channels channels { get; set; }
        public Feed feed { get; set; }
        public Followers followers { get; set; }
        public Following following { get; set; }
        public Groups groups { get; set; }
        public Membership membership { get; set; }
        public ModeratedChannels moderated_channels { get; set; }
        public Portfolios portfolios { get; set; }
        public Videos videos { get; set; }
        public Shared shared { get; set; }
        public FoldersRoot folders_root { get; set; }
        public Teams teams { get; set; }
    }

    public class Credits
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class Embed
    {
        public string html { get; set; }
        public Badges badges { get; set; }
    }

    public class Feed
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
    }

    public class FoldersRoot
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
    }

    public class Followers
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class Following
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class Groups
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class Interactions
    {
        public Report report { get; set; }
    }

    public class Likes
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class Live
    {
        public bool streaming { get; set; }
        public bool archived { get; set; }
    }

    public class LocationDetails
    {
        public string formatted_address { get; set; }
        public object latitude { get; set; }
        public object longitude { get; set; }
        public object city { get; set; }
        public object state { get; set; }
        public object neighborhood { get; set; }
        public object sub_locality { get; set; }
        public object state_iso_code { get; set; }
        public object country { get; set; }
        public object country_iso_code { get; set; }
    }

    public class Membership
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
    }

    public class Metadata
    {
        public Connections connections { get; set; }
        public Interactions interactions { get; set; }
        public bool is_vimeo_create { get; set; }
        public bool is_screen_record { get; set; }
    }

    public class ModeratedChannels
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class Pictures
    {
        public string uri { get; set; }
        public bool active { get; set; }
        public string type { get; set; }
        public string base_link { get; set; }
        public List<Size> sizes { get; set; }
        public string resource_key { get; set; }
        public bool default_picture { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class Play
    {
        public string status { get; set; }
    }

    public class Portfolios
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class Privacy
    {
        public string view { get; set; }
        public string embed { get; set; }
        public bool download { get; set; }
        public bool add { get; set; }
        public string comments { get; set; }
    }

    public class Recommendations
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
    }

    public class Report
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public List<string> reason { get; set; }
    }

    public class RootVimeo
    {
        public string uri { get; set; }
        public string name { get; set; }
        public object description { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public string player_embed_url { get; set; }
        public int duration { get; set; }
        public int width { get; set; }
        public object language { get; set; }
        public int height { get; set; }
        public Embed embed { get; set; }
        public DateTime created_time { get; set; }
        public DateTime modified_time { get; set; }
        public DateTime release_time { get; set; }
        public List<string> content_rating { get; set; }
        public string content_rating_class { get; set; }
        public bool rating_mod_locked { get; set; }
        public object license { get; set; }
        public Privacy privacy { get; set; }
        public Pictures pictures { get; set; }
        public List<object> tags { get; set; }
        public Stats stats { get; set; }
        public List<object> categories { get; set; }
        public Uploader uploader { get; set; }
        public Metadata metadata { get; set; }
        public User user { get; set; }
        public Play play { get; set; }
        public App app { get; set; }
        public string status { get; set; }
        public string resource_key { get; set; }
        public object upload { get; set; }
        public object transcode { get; set; }
        public bool is_playable { get; set; }
        public bool has_audio { get; set; }
    }

    public class Shared
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class Size
    {
        public int width { get; set; }
        public int height { get; set; }
        public string link { get; set; }
        public string link_with_play_button { get; set; }
    }

    public class StaffPick
    {
        public bool normal { get; set; }
        public bool best_of_the_month { get; set; }
        public bool best_of_the_year { get; set; }
        public bool premiere { get; set; }
    }

    public class Stats
    {
        public object plays { get; set; }
    }

    public class Teams
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class Texttracks
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }

    public class Uploader
    {
        public Pictures pictures { get; set; }
    }

    public class User
    {
        public string uri { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public Capabilities capabilities { get; set; }
        public string location { get; set; }
        public string gender { get; set; }
        public object bio { get; set; }
        public object short_bio { get; set; }
        public DateTime created_time { get; set; }
        public Pictures pictures { get; set; }
        public List<object> websites { get; set; }
        public Metadata metadata { get; set; }
        public LocationDetails location_details { get; set; }
        public List<object> skills { get; set; }
        public bool available_for_hire { get; set; }
        public bool can_work_remotely { get; set; }
        public string resource_key { get; set; }
        public string account { get; set; }
    }

    public class Videos
    {
        public string uri { get; set; }
        public List<string> options { get; set; }
        public int total { get; set; }
    }


}
