using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    [Table("Cartao")]
    public class Cartao
    {
        #region propriedades
        [Key]
        public int Id_Catao { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int Nr_Cartao { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public DateTime Dt_Validade { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Nm_Cartao { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Tx_Bandeira { get; set; }

    }
    #endregion
}
