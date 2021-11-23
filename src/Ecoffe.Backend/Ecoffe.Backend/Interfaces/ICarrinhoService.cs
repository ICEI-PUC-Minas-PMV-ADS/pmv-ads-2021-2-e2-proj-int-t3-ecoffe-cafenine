using Ecoffe.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecoffe.Backend.Interfaces
{
    public interface ICarrinhoService
    {
        Task<Carrinho> New(int usuarioId);
        Task<Carrinho> AddProductToCard(int carrinhoId, int produtoId);
    }
}
