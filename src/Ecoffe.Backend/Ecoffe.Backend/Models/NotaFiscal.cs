using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecoffe.Backend.Models
{
    [Table("NotaFiscal")]
    public class NotaFiscal
    {
        [Key]
        public int Id_NotaFiscal { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string NR_NOTA_FISCAL { get; set; }
        public string XML { get; set; }
    }
}
