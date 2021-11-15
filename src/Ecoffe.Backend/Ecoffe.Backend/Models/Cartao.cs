using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecoffe.Backend.Enums;
using Ecoffe.Backend.Interfaces;

namespace Ecoffe.Backend.Models
{
    [Table("Cartao")]
    public class Cartao
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Numero { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataAdicao { get; set; }
        public string NomeTitular { get; set; }
        public string Bandeira { get; set; }
        public string Csv { get; set; }
        public TipoCartao TipoCartao { get; set; }
        public bool Principal { get; set; }
    }
}
