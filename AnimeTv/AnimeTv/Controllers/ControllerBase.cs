using Microsoft.AspNetCore.Http;
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
    public class ControllerBase : Controller
    {
        protected ILogger<HomeController> mLoggingService;
        protected IConfiguration mConfigurationService;
        protected MySqlConnection mConexion;

    }
}
