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
    [Route("[controller]")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotaFiscalController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/Nota Fiscal
        [HttpGet]
        public async Task<IEnumerable<NotaFiscal>> Get()
        {
            var listaNotaFiscal = await _context.NotaFiscal.ToListAsync();

            return listaNotaFiscal;
        }

        //GET: api/cartao/{id}
        [HttpGet("{id}")]
        public async Task<NotaFiscal> GetById([FromRoute] int id)
        {
            var notaFiscal = await _context.NotaFiscal.FindAsync(id);

            if (notaFiscal == null)
                throw new Exception("Nota Fiscal não encontrada.");

            return notaFiscal;
        }

        //POST: api/cartao/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NotaFiscal notaFiscal)
        {
            _context.Add(notaFiscal);
            await _context.SaveChangesAsync();

            return Ok(notaFiscal);
        }

        //PUT: api/cartao/
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] NotaFiscal notaFiscal)
        {
            var notaFiscalDb = await _context.Produto.FindAsync(notaFiscal.Id_NotaFiscal);

            if (notaFiscalDb == null)
                throw new Exception("Id da nota fiscal não encontrado.");

            _context.Update(notaFiscal);
            await _context.SaveChangesAsync();

            return Ok(notaFiscal);
        }

    }
}
