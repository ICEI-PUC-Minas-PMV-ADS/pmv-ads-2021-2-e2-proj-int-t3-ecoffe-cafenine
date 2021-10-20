﻿using Client.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    [Table("PEDIDO")]
    public class Pedido
    {
        #region propriedades       
        [Key] 
        public int Id_Pedido { get; set; }        

        public DateTime DT_Pedido { get; set; }
        public DateTime DataConfirmacao { get; set; }
        public decimal PesoTotal { get; set; }

        #region ForeignKey
        public int Id_Usuario { get; set; }
        public Usuario Usuario { get; set; }
        public int? Id_Cupom { get; set; }
        public Cupom? Cupom { get; set; }
        public int Id_NotaFiscal { get; set; }
        public NotaFiscal NotaFiscal { get; set; }
        public int Id_Frete { get; set; }
        public Frete Frete { get; set; }
        public List<Produto> Produtos { get; set; }
        #endregion
    }
    #endregion
}
