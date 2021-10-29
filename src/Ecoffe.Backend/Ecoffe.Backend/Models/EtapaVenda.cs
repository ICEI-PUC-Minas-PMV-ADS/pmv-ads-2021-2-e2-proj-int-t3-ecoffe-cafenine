using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecoffe.Backend.Models
{
    [Table("EtapaVenda")]
    public class EtapaVenda
    {
        [Key]
        public int Id_Etapa_Venda { get; set; }

        public string Tx_Nome_Usuario { get; set; }
    }
}
