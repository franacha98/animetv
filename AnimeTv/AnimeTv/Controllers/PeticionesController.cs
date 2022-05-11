using AnimeTv.Api;
using AnimeTv.Entity;
using AnimeTv.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebPush;

namespace AnimeTv.Controllers
{
    public class PeticionesController : ControllerBase
    {
        private string mToken;
        private string mAuthToken;
        private string mBaseUrl;
        private ApiWrapper mApiWrapper;
        private GestorVideos mGestorVideo;
        private string mPublicKey;
        private string mPrivateKey;
        private string mSubject;

        public PeticionesController(ILogger<HomeController> pLoggingService, IConfiguration pConfigurationService)
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
            mSubject = mConfigurationService["Subject"];
        }

        public void ComprobarNotificaciones()
        {
            //bool hayMensajesNuevos = ComprobarSiHayNotificacionesNuevas(elementos);
            bool hayMensajesNuevos = true;
            if (hayMensajesNuevos)
            {
                string subject = mSubject;
                string publicKey = mPublicKey;
                string privateKey = mPrivateKey;
                VapidDetails vapidDetails = new VapidDetails(subject, publicKey, privateKey);
                PushSubscription subscription = new PushSubscription(HttpContext.Request.Cookies["endpoint"], HttpContext.Request.Cookies["p256dh"], HttpContext.Request.Cookies["auth"]);
                if (subscription == null)
                {

                }
                WebPushClient webPushClient = new WebPushClient();
                try
                {
                    webPushClient.SendNotification(subscription, "AnimeTV - Mensaje nuevo", vapidDetails);
                }
                catch (Exception exception)
                {
                    HttpContext.Response.Cookies.Append("endpoint", "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
                    HttpContext.Response.Cookies.Append("p256dh", "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
                    HttpContext.Response.Cookies.Append("auth", "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
                }
            }
        }
        public void SuscribirseNotificacionesPush(string pEndpoint, string pP256dh, string pAuth)
        {
            CookieOptions opts = new CookieOptions();
            opts.Expires = DateTime.MaxValue;
            HttpContext.Response.Cookies.Append("endpoint", pEndpoint, opts);
            HttpContext.Response.Cookies.Append("p256dh", pP256dh, opts);
            HttpContext.Response.Cookies.Append("auth", pAuth, opts);
        }

        public void DesuscribirseNotificacionesPush()
        {
            HttpContext.Response.Cookies.Append("endpoint", "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
            HttpContext.Response.Cookies.Append("p256dh", "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
            HttpContext.Response.Cookies.Append("auth", "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
        }
    }
}
