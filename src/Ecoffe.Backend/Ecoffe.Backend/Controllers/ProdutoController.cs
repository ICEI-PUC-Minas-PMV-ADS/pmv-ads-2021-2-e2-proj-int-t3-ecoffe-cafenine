using Ecoffe.Backend.Infrastructure;
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
    public class ProdutoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/produto
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaProdutos = await _context.Produto.ToListAsync();

                return Ok(listaProdutos);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        //GET: api/produto/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var produto = await _context.Produto.Where(p => p.Id == id).FirstOrDefaultAsync();

                if (produto == null)
                    return StatusCode(404, "Produto não encontrado");

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
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
