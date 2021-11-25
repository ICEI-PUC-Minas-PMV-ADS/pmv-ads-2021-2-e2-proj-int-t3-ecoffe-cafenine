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
    public class ProdutoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/produto
        [HttpGet]
        public async Task<IEnumerable<Produto>> Get()
        {
            var listaProdutos = await _context.Produto.ToListAsync();

            return listaProdutos;
        }

        //GET: api/produto/{id}
        [HttpGet("{id}")]
        public async Task<Produto> GetById([FromRoute] int id)
        {
            var produto = await _context.Produto.FindAsync(id);

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            return produto;
        }

        //POST: api/produto/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();

            return Ok(produto);
        }

        //PUT: api/produto/
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Produto produto)
        {
            var produtoDb = await _context.Produto.FindAsync(produto.Id);

            if (produtoDb == null)
                throw new Exception("Produto não encontrado.");

            _context.Update(produto);
            await _context.SaveChangesAsync();

            return Ok(produto);
        }
    }
}
