using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MNG.APIs.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IHostingEnvironment env;

        public InfoController(IHostingEnvironment env)
        {
            this.env = env;
        }

        [HttpGet]
        public ActionResult GetInfo()
        {
            var info = new
            {
                Version = AppVersion(),
                Environment = env.EnvironmentName,
                Date = "2023/12/11"
            }; 

            return Ok(info);
        }

        private string AppVersion()
        {
            var ver = GetType().Assembly.GetName().Version;
            return $"{ver.Major}.{ver.Minor}.{ver.Build}";
        }
    }
}
