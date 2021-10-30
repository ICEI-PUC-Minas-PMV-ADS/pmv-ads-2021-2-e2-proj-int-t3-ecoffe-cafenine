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

        //GET: api/frete/{id}
        [HttpGet("{id}")]
        public async Task<Frete> GetById([FromRoute] int id)
        {
            var frete = await _context.Frete.FindAsync(id);

            if (frete == null)
                throw new Exception("Frete não encontrado.");

            return frete;
        }

        //POST: api/frete/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Frete frete)
        {
            _context.Add(frete);
            await _context.SaveChangesAsync();

            return Ok(frete);
        }

        //PUT: api/frete/
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Frete frete)
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
