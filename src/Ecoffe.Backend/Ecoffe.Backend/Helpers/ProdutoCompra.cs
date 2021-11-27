using Ecoffe.Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecoffe.Backend.Helpers
{
    public class ProdutoCompra
    {       
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        [NotMapped]
        public decimal ValorTotal
        {
            get
            {
                if (Produto != null)
                    return Produto.Valor * Quantidade;
                else
                    return 0;
            }
        }

    }
}
