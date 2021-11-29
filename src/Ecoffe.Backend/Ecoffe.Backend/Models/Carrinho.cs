using Ecoffe.Backend.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Ecoffe.Backend.Models
{
    [Table("Carrinho")]
    public class Carrinho
    {
        [Key]
        public int Id { get; set; }
        public List<ProdutoCarrinho> Produtos { get; set; }

    }
}
