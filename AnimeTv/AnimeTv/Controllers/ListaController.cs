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
    public class ListaController : ControllerBase
    {
        private string mToken;
        private string mAuthToken;
        private string mBaseUrl;
        private ApiWrapper mApiWrapper;
        private GestorVideos mGestorVideo;
        private string mPublicKey;
        private string mPrivateKey;

        public ListaController(ILogger<HomeController> pLoggingService, IConfiguration pConfigurationService)
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

        public IActionResult Index()
        {
            ListaViewModel model = new ListaViewModel();
            string cookieSesion = HttpContext.Request.Cookies["AnimeTV_Sesion"];
            if (string.IsNullOrEmpty(cookieSesion))
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            List<int> listaIDs = mGestorVideo.ObtenerListaDeUnUsuario(cookieSesion);
            List<Data> listaAnimes = new List<Data>();
            foreach (int id in listaIDs)
            {
                listaAnimes.Add(mApiWrapper.ObtenerAnimePorID(id));
                Thread.Sleep(1000);
            }

            model.NombreUsuario = mGestorVideo.ObtenerNombreUsuario(cookieSesion);
            model.ListaAnimes = listaAnimes;

            return View(model);
        }
    }
}
