using System;
using System.Linq;
using System.Threading.Tasks;
using Ecoffe.Backend.Infrastructure;
using Ecoffe.Backend.Interfaces;
using Ecoffe.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecoffe.Backend.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly ApplicationDbContext _context;
        public EnderecoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Endereco> Save(Endereco endereco)
        {
            Validate(endereco);

            var enderecoDb = new Endereco();

            if(endereco.Id != 0)
                enderecoDb = _context.Update(endereco).Entity;

            if (endereco.Id == 0)
                enderecoDb = _context.Add(endereco).Entity;

            await _context.SaveChangesAsync();

            return enderecoDb;
        }

        private void Validate(Endereco endereco)
        {

        }

    }
}
