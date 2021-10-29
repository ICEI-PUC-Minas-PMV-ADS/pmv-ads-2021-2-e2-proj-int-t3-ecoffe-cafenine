using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecoffe.Backend.Models
{
    [Table("Cupom")]
    public class Cupom
    {
        [Key]
        public int Id_Cupom { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public float Vl_Cupom { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Tx_Cupom { get; set; }
    }
}
