using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecoffe.Backend.Models
{
    [Table("Seguranca")]
    public class Seguranca
    {
        [Key]
        public int Id_Cod_Seguranca { get; set; }
        public string Cod_Seguranca { get; set; }
    }
}
