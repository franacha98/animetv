using AnimeTv.Api;
using AnimeTv.Entity;
using AnimeTv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VimeoDotNet;

namespace AnimeTv.Controllers
{
    public class PlayerController : ControllerBase
    {
        private string mToken;
        private string mAuthToken;
        private string mBaseUrl;
        private ApiWrapper mApiWrapper;
        private GestorVideos mGestorVideo;
        private string mPublicKey;
        private string mPrivateKey;

        public PlayerController(ILogger<HomeController> pLoggingService, IConfiguration pConfigurationService)
        {
            mConfigurationService = pConfigurationService;
            mLoggingService = pLoggingService;
            mToken = mConfigurationService["VimeoToken"];
            mAuthToken = mConfigurationService["VimeoAuthToken"];
            mBaseUrl = $"https://api.vimeo.com/";
            mApiWrapper = new ApiWrapper();
            mConexion = new MySqlConnection(mConfigurationService.GetConnectionString("MySQL"));
            mGestorVideo = new GestorVideos(mConexion);
            mPublicKey = mConfigurationService["PublicKey"];
            mPrivateKey = mConfigurationService["PrivateKey"];
            ViewBag.applicationServerKey = mPublicKey;
        }

        public IActionResult Index(int anime, int episodio)
        {
            ViewBag.applicationServerKey = mPublicKey;
         
            int videoID = mGestorVideo.ObtenerVideoPorAnimeYCapitulo(anime, episodio);
            Data data = mApiWrapper.ObtenerAnimePorID(anime);
            VimeoClient vimeoClient = new VimeoClient(mAuthToken);
            string peticion = $"{mBaseUrl}videos/{videoID}";
            string response = Utils.UtilWeb.WebRequest("GET", peticion, mToken, null);
            RootVimeo video = new RootVimeo();
            if (response != "")
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                video = JsonConvert.DeserializeObject<RootVimeo>(response, settings);
            }

            PlayerViewModel model = new PlayerViewModel();
            model.Anime = data.title;
            model.AnimeData = data;
            model.Capitulo = episodio;
            model.UrlVideo = video.player_embed_url;
            model.Noticias = mApiWrapper.ObtenerNoticiasAnime(anime);
            model.VideoID = videoID;
            model.Visto = mGestorVideo.YaVisto(HttpContext.Request.Cookies["AnimeTV_Sesion"], videoID);
            return View(model);
        }

        [HttpGet]
        public string MarcarVisto(int pAnime, int pEpisodio, int pVideo)
        {
            string cookieSesion = HttpContext.Request.Cookies["AnimeTV_Sesion"];
            if (!string.IsNullOrEmpty(cookieSesion)){
                bool marcado = mGestorVideo.MarcarVisto(cookieSesion, pVideo, pAnime, pEpisodio);
                return "OK";
            }
            return "KO";
        }
    }
}
