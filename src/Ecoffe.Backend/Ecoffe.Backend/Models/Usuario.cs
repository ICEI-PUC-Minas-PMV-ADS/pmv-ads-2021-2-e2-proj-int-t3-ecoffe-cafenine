using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecoffe.Backend.Models
{
    [Table("Usuario")]
    public class Usuario
    {       
        [Key] 
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public int? CarrinhoId { get; set; }
        public Carrinho Carrinho { get; set; }
        public List<Cartao> Cartoes { get; set; }
        public List<Compra> Compras { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public bool Admin { get; set; }
    }
}
