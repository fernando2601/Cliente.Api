using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command
{
    public class ClienteCommandHandler : CommandHandler,
         IRequestHandler<RegisterClienteCommand, ValidationResult>,
         IRequestHandler<UpdateClienteCommand, ValidationResult>,
         IRequestHandler<RemoveClienteCommand, ValidationResult>


    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<ValidationResult> Handle(RegisterClienteCommand message, CancellationToken cancellationToken)
        {
            if (message.IsValid())
            {
                if (_clienteRepository.ObterCLientePorEmail(message.Email) != null)
                {
                    AddError("esse email já existe");
                    return ValidationResult;
                }

                if (_clienteRepository.ObterClientePorCnpj(message.Email) != null)
                {
                    AddError("CpfCnpj ja cadastrado");
                    return ValidationResult;
                }

                if (message.TipoPessoa == ClienteConstants.PessoaJuridica)
                {

                    if (message.InscricaoEstadual == null)
                    {
                        AddError("Inscricao estadual obrigatória");
                        return ValidationResult;
                    }
                }

                var cliente = new Clientes(Guid.NewGuid(), message.Nome, message.CpfCnpj, message.TipoPessoa, message.InscricaoEstadual, message.DataNascimento,
                    message.Telefone, message.Email, message.Endereco.Logradouro, message.Endereco.Numero, message.Endereco.Cep,
                    message.Endereco.Bairro, message.Endereco.Cidade, message.Endereco.Estado);

                cliente.AddDomainEvent(new ClienteRegisterEvent(cliente.Id, cliente.Nome, cliente.CpfCnpj, cliente.DataNascimento,
                    cliente.Telefone, cliente.Email, cliente.Logradouro, cliente.Numero, cliente.Cep,
                    cliente.Bairro, cliente.Cidade, cliente.Estado));

                await _clienteRepository.CreateAsync(cliente);
                return await Commit(_clienteRepository.UnitOfWork);


            }
            return message.ValidationResult;

        }

        public async Task<ValidationResult> Handle(UpdateClienteCommand message, CancellationToken cancellationToken)
        {
            if (message.IsValid())
            {

                var cliente = new Clientes(message.Id, message.Nome, message.CpfCnpj, message.TipoPessoa, message.InscricaoEstadual, message.DataNascimento,
                    message.Telefone, message.Email, message.Endereco.Logradouro, message.Endereco.Numero, message.Endereco.Cep,
                    message.Endereco.Bairro, message.Endereco.Cidade, message.Endereco.Estado);

                cliente.AddDomainEvent(new ClienteRegisterEvent(cliente.Id, cliente.Nome, cliente.CpfCnpj, cliente.DataNascimento,
                    cliente.Telefone, cliente.Email, cliente.Logradouro, cliente.Numero, cliente.Cep,
                    cliente.Bairro, cliente.Cidade, cliente.Estado));

                await _clienteRepository.UpdateAsync(cliente);
                return await Commit(_clienteRepository.UnitOfWork);


            }
            return message.ValidationResult;

        }

        public async Task<ValidationResult> Handle(RemoveClienteCommand message, CancellationToken cancellationToken)
        {
            if (message.IsValid())
            {

                await _clienteRepository.DeleteAsync(message.Id);
                return await Commit(_clienteRepository.UnitOfWork);

            }
            return message.ValidationResult;

        }
    }
}