using Ecoffe.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
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
