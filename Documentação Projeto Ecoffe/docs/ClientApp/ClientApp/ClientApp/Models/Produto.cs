using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Client.App.Models
{
    [Table("Produto")]
    public class Produto
    {
        #region propriedades
        [Key]
        public int Id_Produto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Nm_Produto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]

        public float Nr_Peso_Liquido { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatorio")]

        public float Nr_Altura { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatorio")]

        public float Nr_Largura { get; set; }


        public string Tx_Informacao_Comercial { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatorio")]

        public float Vl_Preco_Produto { get; set; }

    }
    #endregion
}
