using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    [Table("NotaFiscal")]
    public class NotaFiscal
    {
        #region propriedades       
        [Key]
        public int Id_NotaFiscal { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string NR_NOTA_FISCAL { get; set; }

        public string XML { get; set; }
    }
    #endregion
}
