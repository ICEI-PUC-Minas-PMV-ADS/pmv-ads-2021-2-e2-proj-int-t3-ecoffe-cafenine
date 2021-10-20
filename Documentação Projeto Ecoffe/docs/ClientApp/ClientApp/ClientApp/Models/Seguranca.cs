using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    [Table("SEGURANCA")]
    public class Seguranca
    {
        #region propriedades
        [Key]
        public int Id_Cod_Seguranca { get; set; }

        public string Cod_Seguranca { get; set; }

    }
    #endregion
}
