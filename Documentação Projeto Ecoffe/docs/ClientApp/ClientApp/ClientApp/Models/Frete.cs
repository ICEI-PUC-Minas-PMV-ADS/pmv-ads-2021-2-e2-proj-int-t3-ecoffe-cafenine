using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    [Table("Frete")]
    public class Frete
    {
        #region propriedades       
        [Key] 
        public int Id_Frete { get; set; }
        public float Vl_Frete { get; set; }
        public string Nm_Status_Frete { get; set; }
        public int Id_Status_Frete { get; set; }
    }
    #endregion
}
