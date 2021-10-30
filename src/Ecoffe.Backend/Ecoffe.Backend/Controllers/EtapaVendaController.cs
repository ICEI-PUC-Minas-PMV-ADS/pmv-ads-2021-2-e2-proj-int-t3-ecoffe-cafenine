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

    //Não estava achando a rota, foi necessário adcionar api/ para que encontrasse
    [Route("api/[controller]")]

    public class EtapaVendaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EtapaVendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/cartao
        [HttpGet]
        public async Task<IEnumerable<EtapaVenda>> Get()
        {
            var listaEtpVenda = await _context.EtapaVenda.ToListAsync();

            return listaEtpVenda;
        }

        //GET: api/cartao/{id}
        [HttpGet("{id}")]
        public async Task<EtapaVenda> GetById([FromRoute] int id)
        {
            var venda = await _context.EtapaVenda.FindAsync(id);

            if (venda == null)
                throw new Exception("Etapa de Venda não encontrada");

            return venda;
        }

        //POST: api/cartao/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EtapaVenda etapaVenda)
        {
            _context.Add(etapaVenda);
            await _context.SaveChangesAsync();

            return Ok(etapaVenda);
        }

        //PUT: api/cartao/
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EtapaVenda etapaVenda)
        {
            var vendaDb = await _context.Produto.FindAsync(etapaVenda.Id_Etapa_Venda);

            if (vendaDb == null)
                throw new Exception("Id da etapa venda não foi encontrado");

            _context.Update(etapaVenda);
            await _context.SaveChangesAsync();

            return Ok(etapaVenda);
        }
    }
}
