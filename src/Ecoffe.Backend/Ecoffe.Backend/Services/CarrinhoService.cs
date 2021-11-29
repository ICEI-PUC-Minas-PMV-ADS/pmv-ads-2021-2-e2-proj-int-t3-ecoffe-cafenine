using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecoffe.Backend.Helpers;
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

        public async Task<Carrinho> AddProductToCard(ProdutoCarrinho produto)
        {
            var carrinhoDb = await _context.Usuario.Include(p => p.Carrinho).ThenInclude(x => x.Produtos).Where(p => p.Id == produto.UsuarioId).Select(p => p.Carrinho).FirstOrDefaultAsync();

            var existingItem = carrinhoDb.Produtos.Where(p => p.ProdutoId == produto.ProdutoId).FirstOrDefault();

            if (existingItem != null)
            {
                existingItem.Quantidade++;
            }
            else
            {
                var productNew = new ProdutoCarrinho()
                {
                    ProdutoId = produto.ProdutoId,
                    UsuarioId = produto.UsuarioId,
                    Quantidade = 1
                };

                carrinhoDb.Produtos.Add(productNew);
            }

            
            await _context.SaveChangesAsync();

            return carrinhoDb;
        }

        public async Task<Carrinho> ClearCart(int usuarioId)
        {
            var carrinhoDb = await _context.Usuario.Include(p => p.Carrinho).ThenInclude(x => x.Produtos).Where(p => p.Id == usuarioId).Select(p => p.Carrinho).FirstOrDefaultAsync();

            if(carrinhoDb == null)
                return await this.New(usuarioId);

            foreach(var item in carrinhoDb.Produtos)
            {
                _context.ProdutoCarrinho.Remove(item);
            }

            await _context.SaveChangesAsync();

            carrinhoDb.Produtos.Clear();

            return carrinhoDb;
        }
    }
}
