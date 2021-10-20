using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    [Table("CUPOM")]
    public class Cupom
    {
        #region Propriedades
        [Key]
        public int Id_Cupom { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public float Vl_Cupom { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Tx_Cupom { get; set; }

    }
    #endregion
}
