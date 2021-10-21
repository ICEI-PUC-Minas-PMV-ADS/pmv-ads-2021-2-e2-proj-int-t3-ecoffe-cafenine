using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        #region propriedades
        [Key]
        public int Id_Endereco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Tx_Endereco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Nr_Endereco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Nr_Cep { get; set; }
    }
    #endregion
}
