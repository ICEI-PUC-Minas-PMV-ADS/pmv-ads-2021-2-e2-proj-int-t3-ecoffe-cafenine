﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        #region propriedades       
        [Key] 
        public int Id_Usuario { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Nm_Usuario { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Tx_Cpf { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Tx_Senha { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string tx_Email { get; set; }

        public int Id_Endereco { get; set; }

        public int Tx_Cnpj { get; set; }
        
        public int Id_Cartao { get; set; }
        public Cartao Cartao { get; set; }

        public int Nr_telefone { get; set; }

        public bool In_Ativo { get; set; }

        public bool In_Admin { get; set; }
 
    }
    #endregion
}
