using Ecoffe.Backend.Enums;
using Ecoffe.Backend.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Ecoffe.Backend.Models
{
    [Table("Carrinho")]
    public class Compra
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataCompra {get; set;}
        public StatusCompra StatusCompra { get; set; }
        public Endereco Endereco { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public List<ProdutoCompra> Produtos { get; set; }
        public Cartao? Cartao { get; set; }
        public int Parcelas { get; set; }
        public decimal ValorBruto
        {
            get
            {
                if (Produtos.Count() > 0)
                {
                    decimal result = 0;

                    foreach (var p in Produtos)
                    {
                        result += p.ValorTotal;
                    }

                    return result;
                }
                else return 0;
            }
            set
            {
                if (Produtos.Count() > 0)
                {
                    decimal result = 0;

                    foreach (var p in Produtos)
                    {
                        result += p.ValorTotal;
                    }

                    ValorBruto = result;
                }
            }
        }
        public decimal ValorParcelas { get; set; }

    }
}
