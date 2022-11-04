using Application.Command;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Entities.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public ClienteAppService(IMapper mapper,
                                  IClienteRepository customerRepository,
                                  IMediatorHandler mediator,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _clienteRepository = customerRepository;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<Clientes> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public async Task<ClienteListaViewModel> GetById(Guid id)
        {
            return _mapper.Map<ClienteListaViewModel>(await _clienteRepository.GetById(id)); ;
        }

        public async Task<ValidationResult> AddAsync(ClienteRegisterViewModel clienteViewModel)
        {
            var registerCommand = _mapper.Map<RegisterClienteCommand>(clienteViewModel);
            var command = await _mediator.SendCommand(registerCommand);
            return command;

        }


        public async Task<ValidationResult> UpdateAsync(UpdateClienteViewModel clienteViewModel)
        {
            var updateCommand = _mapper.Map<UpdateClienteCommand>(clienteViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveClienteCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
