using System;
using System.Linq;
using System.Threading.Tasks;
using Ecoffe.Backend.Infrastructure;
using Ecoffe.Backend.Interfaces;
using Ecoffe.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecoffe.Backend.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;
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
                usuarioDb = _context.Add(usuario).Entity;

            await _context.SaveChangesAsync();

            return usuarioDb;
        }

        private void Validate(Usuario usuario)
        {

        }

    }
}
