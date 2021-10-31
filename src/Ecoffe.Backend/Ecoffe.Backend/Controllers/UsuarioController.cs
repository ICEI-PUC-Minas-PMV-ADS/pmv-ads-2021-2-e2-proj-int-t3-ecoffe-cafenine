using Ecoffe.Backend.Infrastructure;
using Ecoffe.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/usuario/{id}
        [HttpGet("{id}")]
        public async Task<Usuario> GetById([FromRoute] int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            return usuario;
        }

        //POST: api/usuario/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(usuario);
        }
    }
}
