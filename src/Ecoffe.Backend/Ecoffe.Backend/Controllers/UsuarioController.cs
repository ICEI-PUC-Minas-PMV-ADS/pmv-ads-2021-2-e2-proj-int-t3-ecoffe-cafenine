using Ecoffe.Backend.Helpers;
using Ecoffe.Backend.Infrastructure;
using Ecoffe.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        //POST: api/usuario/login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuario loginUsuario)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(p =>
                                                (p.tx_Email == loginUsuario.EmailCpf || p.Tx_Cpf == loginUsuario.EmailCpf) &&
                                                 p.Tx_Senha == loginUsuario.Senha);

            if (usuario == null)
                return StatusCode(404, "Usuário não encontrado.");

            return Ok(usuario);
        }
    }
}
