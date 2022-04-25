using AnimeTv.Entity;
using JikanDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace AnimeTv.Controllers
{
    public class VimeoController : ControllerBase
    {
        private string mToken;
        private string mBaseUrl;
        private readonly IJikan jikan;
        public VimeoController(ILogger<HomeController> pLoggingService, IConfiguration pConfigurationService)
        {
            mConfigurationService = pConfigurationService;
            mLoggingService = pLoggingService;
            mConexion = new MySqlConnection(mConfigurationService.GetConnectionString("MySQL"));
            mToken = mConfigurationService["VimeoToken"];
            mBaseUrl = $"https://api.vimeo.com/";
            jikan = new Jikan();
        }

        public IActionResult Index()
        {
            Video v;
            mConexion.Open();
            var a = mConexion.CreateCommand();
            a.CommandText = "SELECT * FROM videos";
            var reader = a.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                        reader.GetString(1));
                    v = new Video(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }

            mConexion.Close();
            return View("../Home/Index");
        }
        public IActionResult ObtenerVideoEmbed(string pVideoId)
        {
            //string peticion = $"{mBaseUrl}videos/{pVideoId}";
            string peticion = $"{mBaseUrl}me/videos";
            string parametros = "{privacy.comments: anybody, privacy.embed: public, upload.approach: post}";
            string response = UtilWeb.WebRequest("POST", peticion, mToken);


            return View("Home");

        } 
    }
}
