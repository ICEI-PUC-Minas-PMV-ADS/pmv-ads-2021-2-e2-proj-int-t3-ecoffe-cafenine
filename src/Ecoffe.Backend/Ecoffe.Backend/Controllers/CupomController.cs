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
    public class CupomController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CupomController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/cupom
        [HttpGet]
        public async Task<IEnumerable<Cupom>> Get()
        {
            var listaCupom = await _context.Cupom.ToListAsync();

            return listaCupom;
        }

        //GET: api/cupom/{id}
        [HttpGet("{id}")]
        public async Task<Cupom> GetById([FromRoute] int id)
        {
            var cupom = await _context.Cupom.FindAsync(id);

            if (cupom == null)
                throw new Exception("Cupom não encontrado.");

            return cupom;
        }

        //POST: api/cupom/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cupom cupom)
        {
            _context.Add(cupom);
            await _context.SaveChangesAsync();

            return Ok(cupom);
        }

        //PUT: api/cupom/
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cupom cupom)
        {
            var cupomDb = await _context.Produto.FindAsync(cupom.Id_Cupom);

            if (cupomDb == null)
                throw new Exception("Cupom não encontrado.");

            _context.Update(cupom);
            await _context.SaveChangesAsync();

            return Ok(cupom);
        }
    }
}
