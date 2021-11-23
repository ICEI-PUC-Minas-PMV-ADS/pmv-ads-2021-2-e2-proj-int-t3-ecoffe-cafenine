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
        public List<Produto> Produtos { get; set; }
        //[NotMapped]
        //public decimal ValorTotal
        //{
        //    get
        //    {
        //        return Produtos.Sum(p => p.Vl_Preco_Produto);
        //    }
        //}

    }
}
