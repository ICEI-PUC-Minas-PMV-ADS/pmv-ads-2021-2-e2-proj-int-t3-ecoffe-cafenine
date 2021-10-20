using ClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public UsuarioController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Usuario Get()
        {
            var x = new Usuario()
            {
                Nm_Usuario = "teste"
            };

            return x;

        }
    }
}
