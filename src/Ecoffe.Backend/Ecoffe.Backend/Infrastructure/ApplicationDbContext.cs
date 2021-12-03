using Ecoffe.Backend.Helpers;
using Ecoffe.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecoffe.Backend.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Cartao> Cartao { get; set; }
        public DbSet<Cupom> Cupom { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<ProdutoCarrinho> ProdutoCarrinho { get; set; }
        public DbSet<ProdutoCompra> ProdutoCompra { get; set; }
        public DbSet<Compra> Compra { get; set; }
    }
}
