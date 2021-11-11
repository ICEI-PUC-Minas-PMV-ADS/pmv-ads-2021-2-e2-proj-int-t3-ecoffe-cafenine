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
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Usuario usuario;

            try
            {
                usuario = await _context.Usuario
                                    .Where(p => p.Id == id)                    
                                    .Include(p => p.Endereco)
                                    .FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            if (usuario == null)
                return StatusCode(404, "Usuário não encontrado");

            return Ok(usuario);

        }

        //POST: api/usuario/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuario usuario)
        {
            try
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            

            return Ok(usuario);
        }

        //PUT: api/usuario/
        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] Usuario usuario)
        {
            try
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


            return Ok(usuario);
        }

        //POST: api/usuario/login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuario loginUsuario)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(p =>
                                                (p.Email == loginUsuario.EmailCpf || p.CPF == loginUsuario.EmailCpf) &&
                                                 p.Senha == loginUsuario.Senha);

            if (usuario == null)
                return StatusCode(404, "Usuário não encontrado.");

            return Ok(usuario);
        }
    }
}
