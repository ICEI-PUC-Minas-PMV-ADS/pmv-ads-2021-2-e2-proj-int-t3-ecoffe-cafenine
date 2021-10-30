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
    //N estava achando a rota, foi necessário adcionar api/ para que encontrasse
    [Route("api/[controller]")]
    public class SegurancaController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public SegurancaController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/Segurança
        [HttpGet]
        public async Task<IEnumerable<Seguranca>> Get()
        {
            var listaSeguranca = await _context.Seguranca.ToListAsync();

            return listaSeguranca;
        }

        //GET: api/segurança/{id}
        [HttpGet("{id}")]
        public async Task<Seguranca> GetById([FromRoute] int id)
        {
            var seguranca = await _context.Seguranca.FindAsync(id);

            if (seguranca == null)
                throw new Exception("Id de segurança não encontrado.");

            return seguranca;
        }

        //POST: api/segurança/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Seguranca seguranca)
        {
            _context.Add(seguranca);
            await _context.SaveChangesAsync();

            return Ok(seguranca);
        }

        //PUT: api/segurança/
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Seguranca seguranca)
        {
            var segurancaDB = await _context.Produto.FindAsync(seguranca.Id_Cod_Seguranca);

            if (segurancaDB == null)
                throw new Exception("Id não encontrado.");

            _context.Update(seguranca);
            await _context.SaveChangesAsync();

            return Ok(seguranca);
        }
    }
}
