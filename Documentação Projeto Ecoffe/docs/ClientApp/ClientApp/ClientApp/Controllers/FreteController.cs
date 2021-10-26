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
    public class FreteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FreteController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/frete
        [HttpGet]
        public async Task<IEnumerable<Frete>> Get()
        {
            var listaFrete = await _context.Frete.ToListAsync();

            return listaFrete;
        }

        //GET: api/frete/id
        [HttpGet]
        public async Task<Frete> Get(int id)
        {
            var frete = await _context.Frete.FindAsync(id);

            if (frete == null)
                throw new Exception("Frete não encontrado.");

            return frete;
        }

        //POST: api/frete/Frete
        [HttpPost]
        public async Task<IActionResult> Create(Frete frete)
        {
            _context.Add(frete);
            await _context.SaveChangesAsync();

            return Ok(frete);
        }

        //PUT: api/frete/Frete
        [HttpPut]
        public async Task<IActionResult> Update(Frete frete)
        {
            var freteDb = await _context.Produto.FindAsync(frete.Id_Frete);

            if (freteDb == null)
                throw new Exception("Produto não encontrado.");

            _context.Update(frete);
            await _context.SaveChangesAsync();

            return Ok(frete);
        }
    }
}
