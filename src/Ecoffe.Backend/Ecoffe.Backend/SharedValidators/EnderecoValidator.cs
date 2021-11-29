using Ecoffe.Backend.Models;
using System;

namespace Ecoffe.Backend.SharedValidators
{
    public class EnderecoValidator
    {
        public void Validate(Endereco endereco, bool canBeNull)
        {
            if (canBeNull == true)
            {
                if (endereco == null)
                    return;

                if (String.IsNullOrWhiteSpace(endereco.CEP) &&
                String.IsNullOrWhiteSpace(endereco.Rua) &&
                String.IsNullOrWhiteSpace(endereco.Numero) &&
                String.IsNullOrWhiteSpace(endereco.Bairro) &&
                String.IsNullOrWhiteSpace(endereco.Cidade) &&
                String.IsNullOrWhiteSpace(endereco.UF))
                    return;
            }
            
            if (String.IsNullOrWhiteSpace(endereco.CEP) || endereco.CEP.Length != 8)
                throw new Exception("CEP inválido");

            if (String.IsNullOrWhiteSpace(endereco.Rua))
                throw new Exception("Rua deve ser informada");

            if (String.IsNullOrWhiteSpace(endereco.Numero))
                throw new Exception("Número deve ser informado");

            if (String.IsNullOrWhiteSpace(endereco.Bairro))
                throw new Exception("Bairro deve ser informado");

            if (String.IsNullOrWhiteSpace(endereco.Cidade))
                throw new Exception("Cidade deve ser informada");

            if (String.IsNullOrWhiteSpace(endereco.UF))
                throw new Exception("UF deve ser informado");
        }
    }
}
