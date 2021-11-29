using Ecoffe.Backend.Enums;
using Ecoffe.Backend.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Ecoffe.Backend.Models
{
    [Table("Compra")]
    public class Compra
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataCompra {get; set;}
        public StatusCompra StatusCompra { get; set; }
        public int EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        [NotMapped]
        public List<int> ProdutosCompraIdList { get; set; }
        public List<ProdutoCompra> Produtos { get; set; }
        public int? CartaoId { get; set; }
        public Cartao? Cartao { get; set; }
        public int Parcelas { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorParcela { get; set; }

    }
}
