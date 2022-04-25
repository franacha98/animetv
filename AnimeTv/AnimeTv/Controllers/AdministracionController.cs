using AnimeTv.Api;
using AnimeTv.Entity;
using AnimeTv.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Utils;
using VimeoDotNet;
using VimeoDotNet.Models;
using VimeoDotNet.Net;

namespace AnimeTv.Controllers
{
    public class AdministracionController : ControllerBase
    {
        private string mToken;
        private string mAuthToken;
        private string mBaseUrl;
        private ApiWrapper mApiWrapper;
        private GestorVideos mGestorVideo;

        public AdministracionController(ILogger<HomeController> pLoggingService, IConfiguration pConfigurationService)
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
            return View();
        }

        public IActionResult Usuarios()
        {
            return View();
        }

        public IActionResult Videos()
        {
            AdministrarVideosViewModel model = new AdministrarVideosViewModel();
            model.ListaAnimes = mApiWrapper.ObtenerAnimesPorNombre("");

            return View(model);
        }

        public IActionResult BorrarVideoIndex()
        {
            BorrarVideoModel model = new BorrarVideoModel();
            model.ListaVideos = mGestorVideo.CargarTodosLosVideos();           
            model.ListaAnimes = mApiWrapper.ObtenerAnimesPorNombre("");
            return View("../Administracion/BorrarVideo", model);
        }

        public IActionResult BorrarVideo(int pAnime, int pCapitulo)
        {
            mGestorVideo.EliminarVideo(pAnime, pCapitulo);
            return RedirectToAction(actionName: "BorrarVideoIndex");


        }

        [HttpPost]
        public string PeticionAutocompletar(string pNombre)
        {
            string respuesta = JsonConvert.SerializeObject(mApiWrapper.ObtenerAnimesPorNombre(pNombre));
            return respuesta;
        }



        [HttpPost]
        public async Task<IActionResult> SubirVideo([FromForm] IFormFile pVideoFile, int pAnime, int pCapitulo)
        {
            try
            {
                if (pVideoFile != null)
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    VimeoClient vimeoClient = new VimeoClient(mAuthToken);
                    IUploadRequest uploadRequest = new UploadRequest();
                    BinaryContent binaryContent = new BinaryContent(pVideoFile.OpenReadStream(), pVideoFile.ContentType);
                    int chunkSize = 0;
                    int contentLength = Convert.ToInt32(pVideoFile.Length);
                    int temp1 = contentLength / 1024;
                    binaryContent.OriginalFileName = "Test Name";
                    if (temp1 > 1)
                    {
                        chunkSize = temp1 / 1024;
                        if (chunkSize == 0)
                        {
                            chunkSize = 1048576;
                        }
                        else
                        {
                            if (chunkSize > 10)
                            {
                                chunkSize = chunkSize / 10;
                            }
                            chunkSize = chunkSize * 1048576;
                        }
                    }
                    else
                    {
                        chunkSize = 1048576;
                    }
                    var checkChunk = chunkSize;
                    uploadRequest = await vimeoClient.UploadEntireFileAsync(binaryContent);
                    /*insertar en bd la informacion del video*/
                    string videoID = uploadRequest.ClipId.Value.ToString();
                    if (mGestorVideo.InsertarVideo(videoID, pAnime, 1, pCapitulo)) {
                        return RedirectToAction(actionName: "Videos");
                    }
                    else
                    {
                        return BadRequest("Error en la subida del vídeo");
                    }                      
                }
                return BadRequest("Error con el archivo de vídeo solicitado");
            }
            catch (Exception ex)
            {                
                return BadRequest(ex.ToString());
            }

        }
    }
}
