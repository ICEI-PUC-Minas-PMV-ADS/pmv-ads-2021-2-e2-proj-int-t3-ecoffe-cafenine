using Ecoffe.Backend.Helpers;
using Ecoffe.Backend.Infrastructure;
using Ecoffe.Backend.Interfaces;
using Ecoffe.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecoffe.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarrinhoController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/carrinho/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var carrinho = await _context.Carrinho.Where(p => p.Id == id).Include(p => p.Produtos).FirstOrDefaultAsync();

                if (carrinho == null)
                    return StatusCode(404, "Carrinho não encontrado");

                return Ok(carrinho);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }            
        }

        //GET: api/carrinho/usuario/{usuarioId}
        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetByUserId([FromServices] ICarrinhoService carrinhoService, [FromRoute] int usuarioId)
        {
            try
            {
                var usuarioDb = await _context.Usuario.Where(p => p.Id == usuarioId).Include(p => p.Carrinho).ThenInclude(x => x.Produtos).ThenInclude(z => z.Produto).FirstOrDefaultAsync();

                if (usuarioDb == null)
                    return StatusCode(404, "Não foi encontrado usuário cadastrado");

                var carrinhoDb = new Carrinho();

                if(usuarioDb.Carrinho == null)
                    carrinhoDb = await carrinhoService.New(usuarioId);

                carrinhoDb = usuarioDb.Carrinho;       

                return Ok(carrinhoDb);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //POST: api/carrinho/addProduct
        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProductToCard([FromServices] ICarrinhoService carrinhoService, [FromBody] ProdutoCarrinho produtoCarrinho)
        {
            try
            {
                var usuarioDb = await _context.Usuario.Where(p => p.Id == produtoCarrinho.UsuarioId).Include(p => p.Carrinho).FirstOrDefaultAsync();

                if (usuarioDb == null)
                    return StatusCode(404, "Não foi encontrado usuário cadastrado");

                if (usuarioDb.Carrinho == null)
                    usuarioDb.Carrinho = await carrinhoService.New(produtoCarrinho.UsuarioId);

                await carrinhoService.AddProductToCard(produtoCarrinho);

                return Ok(usuarioDb.Carrinho);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //GET: api/carrinho/remove/{produtoCarrinhoId}
        [HttpGet("remove/{produtoCarrinhoId}")]
        public async Task<IActionResult> RemoveProductFromCart([FromRoute] int produtoCarrinhoId)
        {
            try
            {
                var produtoCarrinho = await _context.ProdutoCarrinho.Where(p => p.Id == produtoCarrinhoId).FirstOrDefaultAsync();

                if (produtoCarrinho == null)
                    return StatusCode(404, "Produto do carrinho não encontrado");

                _context.ProdutoCarrinho.Remove(produtoCarrinho);
                var result = await _context.SaveChangesAsync();

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //POST: api/carrinho/updateProdutoCarrinho
        [HttpPost("updateProdutoCarrinho")]
        public async Task<IActionResult> UpdateProdutoCarrinho([FromBody] ProdutoCarrinho produtoCarrinho)
        {
            try
            {
                _context.ProdutoCarrinho.Update(produtoCarrinho);
                await _context.SaveChangesAsync();

                return Ok(produtoCarrinho);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
