using System.ComponentModel.DataAnnotations;

namespace Ecoffe.Backend.Helpers
{
    public class ProdutoCarrinhoCompleto
    {       
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorTotal { get; set; }
        public string Nome { get; set; }
    }
}
