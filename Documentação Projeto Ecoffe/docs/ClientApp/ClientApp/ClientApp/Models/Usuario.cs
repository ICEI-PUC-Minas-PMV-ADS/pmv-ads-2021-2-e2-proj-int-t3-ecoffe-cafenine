using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        #region propriedades       
        [Key] 
        public int Id_Usuario { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Tx_Nome_Usuario { get; set; }

 
    }
    #endregion
}
