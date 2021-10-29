using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecoffe.Backend.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public int Id_Endereco { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Tx_Endereco { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Nr_Endereco { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Nr_Cep { get; set; }
    }
}
