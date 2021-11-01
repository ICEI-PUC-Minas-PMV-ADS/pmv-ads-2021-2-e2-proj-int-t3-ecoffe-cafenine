using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecoffe.Backend.Models
{
    [Table("Usuario")]
    public class Usuario
    {       
        [Key] 
        public int Id_Usuario { get; set; }
        public string Nm_Usuario { get; set; }
        public string Tx_Cpf { get; set; }
        public string Tx_Senha { get; set; }
        public string tx_Email { get; set; }
        public int? Id_Endereco { get; set; }
        public Endereco? endereco { get; set; }
        public string Nr_telefone { get; set; }
        public bool In_Ativo { get; set; }
        public bool In_Admin { get; set; }
    }
}
