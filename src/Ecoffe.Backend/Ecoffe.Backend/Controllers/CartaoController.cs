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

        //POST: api/cartao/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cartao cartao)
        {
            _context.Add(cartao);
            await _context.SaveChangesAsync();

            return Ok(cartao);
        }

        //PUT: api/cartao/
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cartao cartao)
        {
            var cartaoDb = await _context.Produto.FindAsync(cartao.Id);

            if (cartaoDb == null)
                throw new Exception("Cartão não encontrado.");

            _context.Update(cartao);
            await _context.SaveChangesAsync();

            return Ok(cartao);
        }
    }
}
