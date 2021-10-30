﻿using Ecoffe.Backend.Infrastructure;
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
    public class EnderecoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EnderecoController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/endereco
        [HttpGet]
        public async Task<IEnumerable<Endereco>> Get()
        {
            var listaEndereco = await _context.Endereco.ToListAsync();

            return listaEndereco;
        }

        //GET: api/endereco/{id}
        [HttpGet("{id}")]
        public async Task<Endereco> GetById([FromRoute] int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);

            if (endereco == null)
                throw new Exception("Endereco não encontrado.");

            return endereco;
        }

        //POST: api/endereco/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Endereco endereco)
        {
            _context.Add(endereco);
            await _context.SaveChangesAsync();

            return Ok(endereco);
        }

        //PUT: api/endereco/
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Endereco endereco)
        {
            var enderecoDb = await _context.Endereco.FindAsync(endereco.Id_Endereco);

            if (enderecoDb == null)
                throw new Exception("Endereço não encontrado.");

            _context.Update(endereco);
            await _context.SaveChangesAsync();

            return Ok(endereco);
        }
    }
}