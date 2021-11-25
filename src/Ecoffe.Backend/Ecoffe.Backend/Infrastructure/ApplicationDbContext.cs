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
        public DbSet<EtapaVenda> EtapaVenda { get; set; }
        public DbSet<Frete> Frete { get; set; }
        public DbSet<NotaFiscal> NotaFiscal { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Seguranca> Seguranca { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
