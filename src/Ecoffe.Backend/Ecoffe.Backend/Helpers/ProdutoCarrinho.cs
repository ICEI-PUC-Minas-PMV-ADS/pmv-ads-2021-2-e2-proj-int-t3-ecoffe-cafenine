using System.ComponentModel.DataAnnotations;

namespace Ecoffe.Backend.Helpers
{
    public class ProdutoCarrinho
    {       
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
