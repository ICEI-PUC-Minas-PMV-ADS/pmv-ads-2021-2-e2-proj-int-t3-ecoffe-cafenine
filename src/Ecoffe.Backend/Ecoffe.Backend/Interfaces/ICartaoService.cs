using Ecoffe.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecoffe.Backend.Interfaces
{
    public interface ICartaoService
    {
        Task<Cartao> Save(Cartao cartao);

        Task<Cartao> TurnCardPrincipal(int cartaoId);
    }
}
