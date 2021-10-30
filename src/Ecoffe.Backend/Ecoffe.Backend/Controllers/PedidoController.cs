using Ecoffe.Backend.Infrastructure;
using Ecoffe.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecoffe.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/pedido
        [HttpGet]
        public async Task<IEnumerable<Pedido>> Get()
        {
            var listaPedidos = await _context.Pedido.ToListAsync();

            return listaPedidos;
        }

        //GET: api/pedido/{id}
        [HttpGet("{id}")]
        public async Task<Pedido> GetById([FromRoute] int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);

            if (pedido == null)
                throw new Exception("Pedido não encontrado.");

            return pedido;
        }

        //POST: api/pedido/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Pedido pedido)
        {
            _context.Add(pedido);
            await _context.SaveChangesAsync();

            return Ok(pedido);
        }

        //PUT: api/pedido/
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Pedido pedido)
        {
            var pedidoDb = await _context.Produto.FindAsync(pedido.Id_Pedido);

            if (pedidoDb == null)
                throw new Exception("Produto não encontrado.");

            _context.Update(pedido);
            await _context.SaveChangesAsync();

            return Ok(pedido);
        }
    }
}
