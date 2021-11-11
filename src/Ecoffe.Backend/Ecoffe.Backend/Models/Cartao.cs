using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecoffe.Backend.Enums;

namespace Ecoffe.Backend.Models
{
    [Table("Cartao")]
    public class Cartao
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime Vencimento { get; set; }
        public string NomeTitular { get; set; }
        public string CpfTitular { get; set; }
        public string Bandeira { get; set; }
        public string Csv { get; set; }
        public TipoCartao TipoCartao { get; set; }
    }
}
