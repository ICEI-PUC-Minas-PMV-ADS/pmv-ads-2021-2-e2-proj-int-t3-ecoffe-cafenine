using Ecoffe.Backend.Infrastructure;
using Ecoffe.Backend.Interfaces;
using Ecoffe.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecoffe.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartaoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/cartao
        [HttpGet]
        public async Task<IEnumerable<Cartao>> Get()
        {
            var listaCartoes = await _context.Cartao.ToListAsync();

            return listaCartoes;
        }

        //GET: api/cartao/{id}
        [HttpGet("{id}")]
        public async Task<Cartao> GetById([FromRoute] int id)
        {
            var cartao = await _context.Cartao.FindAsync(id);

            if (cartao == null)
                throw new Exception("Cartão não encontrado.");

            return cartao;
        }

        //GET: api/cartao/usuario/{usuarioId}
        [HttpGet("usuario/{usuarioId}")]
        public async Task<IEnumerable<Cartao>> GetListByUserId([FromRoute] int usuarioId)
        {
            try
            {
                return await _context.Cartao.Where(p => p.UsuarioId == usuarioId).ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //GET: api/cartao/principal/{cartaoId}
        [HttpGet("principal/{cartaoId}")]
        public async Task<IActionResult> TurnCardPrincipal([FromServices] ICartaoService cartaoService, [FromRoute] int cartaoId)
        {
            try
            {
                return Ok(await cartaoService.TurnCardPrincipal(cartaoId));
            } 
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }        
        }

        //POST: api/cartao/
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] ICartaoService cartaoService, [FromBody] Cartao cartao)
        {
            try
            {
                await cartaoService.Save(cartao);
                return Ok(cartao);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }           
        }

        //DELETE: api/cartao/{cartaoId}
        [HttpDelete("{cartaoId}")]
        public async Task<ActionResult> Delete([FromRoute] int cartaoId)
        {
            var cartao = await _context.Cartao
                .Where(p => p.Id == cartaoId)
                .FirstOrDefaultAsync();

            if (cartao == null)
                return StatusCode(404, "Cartão não encontrado");

            try
            {
                _context.Remove(cartao);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
            return Ok(cartao);
        }
    }
}
