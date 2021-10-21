using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Models
{

    [Table("EtapaVenda")]
    public class EtapaVenda
    {
        #region propriedades       
        [Key]
        public int Id_Etapa_Venda { get; set; }

        public string Tx_Nome_Usuario { get; set; }

    }
    #endregion
}
