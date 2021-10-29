using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecoffe.Backend.Models
{
    [Table("Frete")]
    public class Frete
    {
        [Key] 
        public int Id_Frete { get; set; }
        public float Vl_Frete { get; set; }
        public string Nm_Status_Frete { get; set; }
        public int Id_Status_Frete { get; set; }
    }
}
