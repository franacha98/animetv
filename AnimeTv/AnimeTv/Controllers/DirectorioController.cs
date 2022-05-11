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
    public class DirectorioController : ControllerBase
    {
        private string mToken;
        private string mAuthToken;
        private string mBaseUrl;
        private ApiWrapper mApiWrapper;
        private GestorVideos mGestorVideo;
        private string mPublicKey;
        private string mPrivateKey;

        public DirectorioController(ILogger<HomeController> pLoggingService, IConfiguration pConfigurationService)
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
            ViewBag.applicationServerKey = mPublicKey;
            int limite = 20;
            DirectorioAnimeViewModel model = new DirectorioAnimeViewModel();
            model.ListaAnimes = mApiWrapper.ObtenerAnimesPorNombre("", 1, limite);
            Thread.Sleep(1000);
            model.Generos = mApiWrapper.ObtenerListadoGeneros();
            model.InfoPaginas = mApiWrapper.ObtenerInfoPaginacion(limite);
            return View(model);
        }

        [HttpGet]
        public IActionResult Filtrar(int pGenero, int pPagina, string pOrden, string pEstado)
        {
            ViewBag.applicationServerKey = mPublicKey;
            int limite = 20;
            DirectorioAnimeViewModel model = new DirectorioAnimeViewModel();
            model.ListaAnimes = mApiWrapper.ObtenerAnimesFiltrados(pGenero, pPagina, pOrden, pEstado);
            model.Generos = mApiWrapper.ObtenerListadoGeneros();
            model.InfoPaginas = mApiWrapper.ObtenerInfoPaginacion(limite);
            model.GeneroSeleccionado = pGenero;
            model.OrdenSeleccionado = pOrden;
            model.EstadoSeleccionado = pEstado;
            return View("../Directorio/Index", model);
        }
    }
}
