using AnimeTv.Api;
using AnimeTv.Entity;
using AnimeTv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Utils;

namespace AnimeTv.Controllers
{
    public class HomeController : ControllerBase
    {
        private string mToken;
        private string mAuthToken;
        private string mBaseUrl;
        private ApiWrapper mApiWrapper;
        private GestorVideos mGestorVideo;

        public HomeController(ILogger<HomeController> pLoggingService, IConfiguration pConfigurationService)
        {
            mConfigurationService = pConfigurationService;
            mLoggingService = pLoggingService;
            mToken = mConfigurationService["VimeoToken"];
            mAuthToken = mConfigurationService["VimeoAuthToken"];
            mBaseUrl = $"https://api.vimeo.com/";
            mApiWrapper = new ApiWrapper();
            mConexion = new MySqlConnection(mConfigurationService.GetConnectionString("MySQL"));
            mGestorVideo = new GestorVideos(mConexion);
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.AnimesEnEmision = mApiWrapper.ObtenerAnimesEnEmision();
            model.ProximosAnimes = mApiWrapper.ObtenerProximosEstrenos();
            Thread.Sleep(1000);
            List<Episodios> ultimosEpisodios = mApiWrapper.ObtenerUltimosEpisodios();
            List<Episodios> ultimosEpisodiosAcortados = new List<Episodios>();
            int i = 0;
            foreach (var anime in ultimosEpisodios)
            {
                if (i >= 16)
                {
                    break;
                }
                else
                {
                    ultimosEpisodiosAcortados.Add(anime);
                    i++;
                }
                
            }
            model.EpisodiosRecientes = ultimosEpisodiosAcortados;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
