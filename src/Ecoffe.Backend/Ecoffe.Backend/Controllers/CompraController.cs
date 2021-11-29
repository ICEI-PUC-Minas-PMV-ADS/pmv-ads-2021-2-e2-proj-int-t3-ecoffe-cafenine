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
    public class CompraController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompraController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/compra/{compraId}
        [HttpGet("{compraId}")]
        public async Task<IActionResult> GetByPurchaseId([FromRoute] int compraId)
        {
            try
            {
                var compra = await _context.Compra.Where(p => p.Id == compraId)
                                                  .Include(p => p.Cartao)
                                                  .Include(p => p.Endereco)
                                                  .Include(p => p.Produtos)
                                                    .ThenInclude(z => z.Produto)
                                                  .OrderByDescending(p => p.DataCompra)
                                                  .FirstOrDefaultAsync();

                if (compra == null)
                    return StatusCode(404, "Compra não encontrada");

                return Ok(compra);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //GET: api/compra/usuario/{usuarioId}
        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetListByUserId([FromRoute] int usuarioId)
        {
            try
            {
                var usuario = await _context.Usuario.Where(p => p.Id == usuarioId).Include(p => p.Compras).FirstOrDefaultAsync();

                if (usuario == null)
                    return StatusCode(404, "Usuário não encontrado");

                var compras = usuario.Compras.OrderByDescending(p => p.DataCompra);

                if (compras == null)
                    return StatusCode(404, "Nenhuma compra encontrada");

                return Ok(compras);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //GET: api/compra/usuario/recente/{usuarioId}
        [HttpGet("usuario/recente/{usuarioId}")]
        public async Task<IActionResult> GetLatestByUserId([FromRoute] int usuarioId)
        {
            try
            {
                var compra = await _context.Compra.Where(p => p.UsuarioId == usuarioId)
                                                  .Include(p => p.Cartao)
                                                  .Include(p => p.Endereco)
                                                  .Include(p => p.Produtos)
                                                    .ThenInclude(z => z.Produto)
                                                  .OrderByDescending(p => p.DataCompra)
                                                  .FirstOrDefaultAsync();

                if (compra == null)
                    return StatusCode(404, "Compra não encontrada para este usuário");

                return Ok(compra);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //POST: api/compra/
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] ICompraService compraService, [FromBody] Compra compra)
        {
            try
            {
                await compraService.Save(compra);
                return Ok(compra);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }           
        }
    }
}
