using System;
using System.Linq;
using System.Threading.Tasks;
using Ecoffe.Backend.Infrastructure;
using Ecoffe.Backend.Interfaces;
using Ecoffe.Backend.Models;
using Ecoffe.Backend.SharedValidators;
using Microsoft.EntityFrameworkCore;

namespace Ecoffe.Backend.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;
        private readonly EnderecoValidator _enderecoValidator = new EnderecoValidator();
        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Save(Usuario usuario)
        {
            Validate(usuario);

            var usuarioDb = new Usuario();

            if(usuario.Id != 0)
                usuarioDb = _context.Update(usuario).Entity;

            if (usuario.Id == 0)
            {
                usuario.Endereco = new Endereco();
                usuarioDb = _context.Add(usuario).Entity;
            }

            await _context.SaveChangesAsync();

            return usuarioDb;
        }

        private void Validate(Usuario usuario)
        {
            if (String.IsNullOrWhiteSpace(usuario.Nome))
                throw new Exception("Nome deve ser informado");

            if (usuario.CPF == null || usuario.CPF.Length != 11 || long.TryParse(usuario.CPF, out long n) == false)
                throw new Exception("CPF inválido");

            if (String.IsNullOrWhiteSpace(usuario.Email))
                throw new Exception("Email inválido");

            _enderecoValidator.Validate(usuario.Endereco, true);
        }

    }
}
