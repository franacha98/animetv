using AnimeTv.Api;
using AnimeTv.Entity;
using AnimeTv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AnimeTv.Controllers
{
    public class FichaController : ControllerBase
    {
        private string mToken;
        private string mAuthToken;
        private string mBaseUrl;
        private ApiWrapper mApiWrapper;
        private GestorVideos mGestorVideo;
        private string mPublicKey;
        private string mPrivateKey;

        public FichaController(ILogger<HomeController> pLoggingService, IConfiguration pConfigurationService)
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

        public IActionResult Index(int id)
        {
            ViewBag.applicationServerKey = mPublicKey;
            FichaViewModel model = new FichaViewModel();
            Data anime = mApiWrapper.ObtenerAnimePorID(id);
            Thread.Sleep(1000);
            model.AnimeData = anime;
            model.Productora = anime.producers.FirstOrDefault().name;
            model.Estudio = anime.studios.FirstOrDefault().name;
            model.Capitulos = anime.episodes;
            model.Emision = anime.airing;
            model.Id = anime.mal_id;
            model.Nombre = anime.title;
            model.Generos = anime.demographics;
            model.Episodios = mApiWrapper.ObtenerEpisodiosAnime(id);
            model.Count = 0;

            return View(model);
        }
    }
}
