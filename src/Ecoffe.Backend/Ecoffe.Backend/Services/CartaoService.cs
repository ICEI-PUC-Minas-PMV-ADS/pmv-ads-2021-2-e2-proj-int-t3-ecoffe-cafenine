using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ecoffe.Backend.Enums;
using Ecoffe.Backend.Infrastructure;
using Ecoffe.Backend.Interfaces;
using Ecoffe.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecoffe.Backend.Services
{
    public class CartaoService : ICartaoService
    {
        private readonly ApplicationDbContext _context;
        public CartaoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cartao> Save(Cartao cartao)
        {
            Validate(cartao);

            if (cartao.Principal == true)
                await TurnOtherCardsSecundary(cartao.Id, cartao.UsuarioId);

            var cartaoDb = _context.Add(cartao);
            await _context.SaveChangesAsync();

            return cartaoDb.Entity;
        }

        private void Validate(Cartao cartao)
        {

        }

        public async Task<Cartao> TurnCardPrincipal(int cartaoId)
        {
            var selectedCard =  await _context.Cartao
                .Where(p => p.Id == cartaoId)
                .FirstOrDefaultAsync();

            if (selectedCard == null)
                throw new Exception("Cartão não encontrado");

            selectedCard.Principal = true;

            await _context.SaveChangesAsync();

            await TurnOtherCardsSecundary(cartaoId, selectedCard.UsuarioId);

            return selectedCard;
        }

        private async Task TurnOtherCardsSecundary(int cartaoId, int usuarioId)
        {
            var allSecundaryCardsList = await _context.Cartao
                .Where(p =>
                       p.UsuarioId == usuarioId &&
                       p.Id != cartaoId)
                .ToListAsync();

            foreach (var secundaryCard in allSecundaryCardsList)
                secundaryCard.Principal = false;

            await _context.SaveChangesAsync();
        }
    }
}
