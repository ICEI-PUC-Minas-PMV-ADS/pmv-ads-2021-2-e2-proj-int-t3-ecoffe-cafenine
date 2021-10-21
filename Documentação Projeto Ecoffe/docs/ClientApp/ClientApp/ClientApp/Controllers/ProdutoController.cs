using Client.App.Models;
using ClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Controllers
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

        //POST: api/produto/Produto
        [HttpPost]
        public async Task<IActionResult> Create(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();

            return Ok(produto);
        }
    }
}
