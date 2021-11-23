using System;
using System.Linq;
using System.Threading.Tasks;
using Ecoffe.Backend.Infrastructure;
using Ecoffe.Backend.Interfaces;
using Ecoffe.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecoffe.Backend.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ApplicationDbContext _context;
        public CarrinhoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Carrinho> New(int usuarioId)
        {
            var userDb = await _context.Usuario.FindAsync(usuarioId);

            var carrinho = new Carrinho();

            userDb.Carrinho = carrinho;

            var userDbUpdated = _context.Update(userDb);
            await _context.SaveChangesAsync();

            return userDbUpdated.Entity.Carrinho;
        }

        public async Task<Carrinho> AddProductToCard(int carrinhoId, int produtoId)
        {
            var carrinhoDb = await _context.Carrinho.FindAsync(carrinhoId);

            var productNew = new Produto() {
                Id = produtoId
            };

            carrinhoDb.Produtos.Add(productNew);
            await _context.SaveChangesAsync();

            return carrinhoDb;
        }
    }
}
