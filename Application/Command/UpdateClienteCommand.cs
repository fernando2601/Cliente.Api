using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command
{
    public class UpdateClienteCommand : ClienteCommand
    {
        public UpdateClienteCommand(Guid id, string nome, string email, DateTime dataNascimento, string cpfCnpj, string telefone, Endereco endereco
           )
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            CpfCnpj = cpfCnpj;
            Telefone = telefone;


        }

        public override bool IsValid()
        {
            ValidationResult = new ClienteValidador().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
