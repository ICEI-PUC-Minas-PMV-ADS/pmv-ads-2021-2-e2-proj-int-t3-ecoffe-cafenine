using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecoffe.Backend.Enums;
using Ecoffe.Backend.Helpers;
using Ecoffe.Backend.Infrastructure;
using Ecoffe.Backend.Interfaces;
using Ecoffe.Backend.Models;
using Ecoffe.Backend.SharedValidators;
using Microsoft.EntityFrameworkCore;

namespace Ecoffe.Backend.Services
{
    public class CompraService : ICompraService
    {
        private readonly ApplicationDbContext _context;
        private readonly EnderecoValidator _enderecoValidator = new EnderecoValidator();
        private readonly ICarrinhoService carrinhoService;
        public CompraService(ApplicationDbContext context, ICarrinhoService carrinhoService)
        {
            this.carrinhoService = carrinhoService;
            _context = context;
        }

        public async Task<Compra> Save(Compra compra)
        {
            var produtosCarrinho = await _context.ProdutoCarrinho.Where(p => compra.ProdutosCompraIdList.Contains(p.Id)).ToListAsync();

            if (compra.Produtos == null)
                compra.Produtos = new List<ProdutoCompra>();

            foreach (var produto in produtosCarrinho)
            {
                var produtoCompra = new ProdutoCompra()
                {
                    ProdutoId = produto.ProdutoId,
                    Produto = produto.Produto,
                    Quantidade = produto.Quantidade,
                    UsuarioId = produto.UsuarioId
                };

                compra.Produtos.Add(produtoCompra);
            }

            Validate(compra);

            var usuario = await _context.Usuario.Where(p => p.Id == compra.UsuarioId).Include(p => p.Compras).FirstOrDefaultAsync();

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            usuario.Compras.Add(compra);

            if(compra.EnderecoId == 0)
                compra.Endereco = _context.Endereco.Add(compra.Endereco).Entity;

            var compraDb = _context.Add(compra);
            await _context.SaveChangesAsync();

            await carrinhoService.ClearCart(compra.UsuarioId);

            return compraDb.Entity;
        }

        private void Validate(Compra compra)
        {
            if (compra.Produtos.Count() == 0)
                throw new Exception("Não é possível realizar compra sem nenhum produto");

            if (compra.FormaPagamento == FormaPagamento.Debito || compra.FormaPagamento == FormaPagamento.Credito)
                if (compra.CartaoId == null)
                    throw new Exception("Deve ser selecionado um cartão");

            if (compra.EnderecoId == 0)
                _enderecoValidator.Validate(compra.Endereco, false);

        }
    }
}
