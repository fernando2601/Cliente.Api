using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Validation
{
    public class ClienteValidador : AbstractValidator<ClienteCommand>
    {
        public ClienteValidador()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Digite seu Nome")
                .Length(2, 150).WithMessage("O nome tem que estar entre 2 e 150 caracteres");

            RuleFor(c => c.DataNascimento)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("o cliente tem que ter mais de 18 anos");

            RuleFor(c => c.CpfCnpj)
                .NotEmpty();


            RuleFor(c => c.Telefone)
                .NotEmpty();

            RuleFor(c => c.Email)
              .NotEmpty();

            RuleFor(c => c.Endereco.Bairro)
              .NotEmpty();

            RuleFor(c => c.Endereco.Cep)
              .NotEmpty();

            RuleFor(c => c.Endereco.Cidade)
              .NotEmpty();
            RuleFor(c => c.Endereco.Estado)
              .NotEmpty();


        }
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        private bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}
