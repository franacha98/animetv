using AnimeTv.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Controllers
{
    public class SesionController : ControllerBase
    {

        private GestorVideos mGestorVideo;

        public SesionController(ILogger<HomeController> pLoggingService, IConfiguration pConfigurationService)
        {
            mConfigurationService = pConfigurationService;
            mLoggingService = pLoggingService;
            mConexion = new MySqlConnection(mConfigurationService.GetConnectionString("MySQL"));
            mGestorVideo = new GestorVideos(mConexion);           
        }


        [HttpPost]
        public IActionResult Login(string pEmail, string pPassword)
        {
            bool login = mGestorVideo.Login(pEmail, pPassword);
            if (login)
            {
                HttpContext.Response.Cookies.Append("AnimeTV_Sesion", pEmail, new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.Now.AddDays(1) });
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpPost]
        public IActionResult Registro(string pNombre, string pEmail, string pPassword)
        {
            bool login = mGestorVideo.Registro(pEmail, pNombre, pPassword);
            if (login)
            {
                HttpContext.Response.Cookies.Append("AnimeTV_Sesion", pEmail, new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.Now.AddDays(1) });
            }

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
    }
}
